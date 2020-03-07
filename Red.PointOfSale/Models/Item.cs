using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Models
{
    public class Item : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ItemDepartment Department { get; set; }
        public Item Parent { get; set; }
        public List<ItemDetail> Details { get; set; }
        
        public Item() : this("")
        {
        }
        
        public Item(string code) : this(code, "", 0)
        {
            Details = new List<ItemDetail>();
        }
        
        public Item(string code, string name, double price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }
        
        public void AddDetail(ItemDetail detail)
        {
            detail.Item = this;
            Details.Add(detail);
        }
    }
    
    public class ItemDetail : BaseModel
    {
        public Item Item { get; set; }
        public string StockNumber { get; set; }
        public string Code { get; set; }
        public double Ratio { get; set; }
        public double MarkUp { get; set; }
        public double Price { get; set; }
    }

    public class ItemDepartment : BaseModel
    {
        public string Name { get; set; }
    }

    public class ItemJournal : BaseModel
    {
        public Item Item { get; set; }
        public double QuantityIn { get; set; }
        public double QuantityOut { get; set; }
        public DateTime Date { get; set; }
    }

    public class ItemEventArgs : EventArgs
    {
        public Item Item { get; set; }

        public ItemEventArgs(Item item)
        {
            this.Item = item;
        }
    }
}
