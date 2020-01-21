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
        public List<Payment> Payments { get; set; }
        public DateTime Date { get; set; }
        public Account IncomeAccount { get; set; }
        public string RefNo { get; set; }

        public const int Pending = 1;

        public SalesReceipt()
        {
            Date = DateTime.Now;
            Items = new List<SalesReceiptItem>();
            Payments = new List<Payment>();
        }
        
        public double TotalPayments {
            get {
                double amount = 0;
                foreach (var p in Payments) {
                    amount += p.Amount;
                }
                return amount;
            }
        }
        
        public double TotalChange {
            get { return TotalPayments - TotalAmount; }
        }

        public void AddItems(List<SalesReceiptItem> items)
        {
            foreach (var i in items) {
                AddItem(i);
            }
        }
        
        public void AddPayment(Payment payment)
        {
            payment.Receipt = this;
            Payments.Add(payment);
        }
        
        public void AddItem(Item item)
        {
            AddItem(item, 1);
        }
        
        public void AddItem(Item item, double quantity)
        {
            AddItem(new SalesReceiptItem(item, quantity));
        }

        public void AddItem(SalesReceiptItem item)
        {
            item.Receipt = this;
            Items.Insert(0, item);
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

    public class SalesReceiptEventArgs : EventArgs
    {
        public SalesReceipt Receipt { get; set; }
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

        public SalesReceiptItem(Item item) : this(item, 1)
        {
        }
        
        public SalesReceiptItem(Item item, double quantity) : this(item, quantity, item.Price)
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
