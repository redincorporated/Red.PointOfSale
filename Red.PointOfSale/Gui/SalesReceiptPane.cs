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
        SalesReceipt receipt = new SalesReceipt();

        public SalesReceiptPane()
        {
            InitializeComponent();
            ActiveControl = textBox1;
            textBox1.Select();
            textBox1.Focus();
            ItemsChanged += SalesReceiptPane_ItemsChanged;
            textBox1.LostFocus += delegate (object sender, EventArgs e) {
                textBox1.Focus();
            };
        }

        public void Save()
        {
            OnSalesReceiptSave(null);
        }

        private void SalesReceiptPane_ItemsChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var i in receipt.Items) {
                var li = listView1.Items.Add(i.Item.Name);
                li.SubItems.Add(i.Quantity.ToString());
                li.SubItems.Add(i.Price.ToString());
                li.SubItems.Add(i.Amount.ToString());
            }
        }

        public SalesReceipt Receipt {
            get { return receipt; }
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
        public event EventHandler CustomerSearch;
        public event EventHandler ItemsChanged;
        public event EventHandler SalesReceiptSave;

        protected virtual void OnSalesReceiptSave(EventArgs e)
        {
            if (SalesReceiptSave != null) {
                SalesReceiptSave(this, e);
            }
        }

        protected virtual void OnItemsChanged(EventArgs e)
        {
            if (ItemsChanged != null) {
                ItemsChanged(this, e);
            }
        }

        protected virtual void OnCustomerSearch(EventArgs e)
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                OnItemSearch(new ItemEventArgs(new Item { Code = textBox1.Text }));
                textBox1.Clear();
            }
        }
    }
}
