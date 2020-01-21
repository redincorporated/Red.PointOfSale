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
        
        public Item()
        {
        }
        
        public Item(string code) : this(code, "", 0)
        {
        }
        
        public Item(string code, string name, double price)
        {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }
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
