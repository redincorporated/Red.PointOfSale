using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Gui
{
    public partial class SalesReceiptPane : UserControl
    {
        SalesReceipt receipt;

        public SalesReceiptPane()
        {
            InitializeComponent();

            ActiveControl = textBoxItemCode;

            textBoxItemCode.Select();
            textBoxItemCode.Focus();
            textBoxItemCode.LostFocus += delegate (object sender, EventArgs e) {
                textBoxItemCode.Focus();
            };

            textBoxItemCode.KeyDown += TextBoxItemCode_KeyDown;

            ItemsChanged += SalesReceiptPane_ItemsChanged;
            
            Receipt = new SalesReceipt();
        }
        
        public void SearchCustomer(string code)
        {
            OnCustomerSearch(new CustomerEventArgs(new Customer(code)));
        }
        
        public void SearchItem(string code)
        {
            textBoxItemCode.Text = code;
            TextBoxItemCode_KeyDown(this, new KeyEventArgs(Keys.Enter));
        }

        private void TextBoxItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                OnItemSearch(new ItemEventArgs(new Item { Code = textBoxItemCode.Text }));
                textBoxItemCode.Clear();
            }
        }

        public void PerformSave()
        {
            OnSave(null);
        }

        private void SalesReceiptPane_ItemsChanged(object sender, EventArgs e)
        {
            listViewItems.Items.Clear();
            foreach (var i in receipt.Items) {
                var li = listViewItems.Items.Add(i.Item.Name);
                li.SubItems.Add(i.Quantity.ToString());
                li.SubItems.Add(i.Price.ToString());
                li.SubItems.Add(i.Amount.ToString());
            }
        }

        public SalesReceipt Receipt {
            get {
                receipt.Date = DateTime.Now;
                return receipt;
            }
            set {
                receipt = value;
            }
        }

        public void AddItem(Item item)
        {
            AddItem(new SalesReceiptItem(item));
        }

        public void AddItem(SalesReceiptItem item)
        {
            receipt.AddItem(item);
            OnItemsChanged(null);
        }

        public event EventHandler<ItemEventArgs> ItemSearch;
        public event EventHandler<CustomerEventArgs> CustomerSearch;
        public event EventHandler ItemsChanged;
        public event EventHandler<SalesReceiptEventArgs> Save;

        protected virtual void OnSave(SalesReceiptEventArgs e)
        {
            if (Save != null) {
                Save(this, e);
            }
        }

        protected virtual void OnItemsChanged(EventArgs e)
        {
            if (ItemsChanged != null) {
                ItemsChanged(this, e);
            }
        }

        protected virtual void OnCustomerSearch(CustomerEventArgs e)
        {
            if (CustomerSearch != null) {
                CustomerSearch(this, e);
            }
        }

        protected virtual void OnItemSearch(ItemEventArgs e)
        {
            if (ItemSearch != null) {
                ItemSearch(this, e);
            }
        }
    }
}
