using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Models
{
    public class Customer : BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public Customer()
        {
        }
        
        public Customer(string code)
        {
            this.Code = code;
        }
    }
    
    public class CustomerEventArgs : EventArgs
    {
        public Customer Customer { get; set; }
        
        public CustomerEventArgs(Customer customer)
        {
            this.Customer = customer;
        }
    }
}
