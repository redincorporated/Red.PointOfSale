using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Models
{
    public class SalesReceipt : BaseModel
    {
        public Customer Customer { get; set; }
        public List<SalesReceiptItem> Items { get; set; }
        public DateTime Date { get; set; }
        public Account IncomeAccount { get; set; }
        public string RefNo { get; set; }

        public const int Pending = 1;

        public SalesReceipt()
        {
            Items = new List<SalesReceiptItem>();
        }

        public void AddItem(List<SalesReceiptItem> items)
        {
            foreach (var i in items) {
                AddItem(i);
            }
        }

        public void AddItem(SalesReceiptItem item)
        {
            item.Receipt = this;
            Items.Add(item);
        }

        public double TotalAmount {
            get {
                double amount = 0;
                foreach (var i in Items) {
                    amount += i.Amount;
                }
                return amount;
            }
        }
    }

    public class SalesReceiptItem : BaseModel
    {
        public SalesReceipt Receipt { get; set; }
        public Item Item { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Amount {
            get { return Quantity * Price; }
        }

        public SalesReceiptItem() { }

        public SalesReceiptItem(Item item) : this(item, 1, item.Price)
        {
        }

        public SalesReceiptItem(Item item, double quantity, double price)
        {
            this.Item = item;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
