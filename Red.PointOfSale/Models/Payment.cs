using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Models
{
    public class Payment : BaseModel
    {
        public const int Cash = 1;
        public const int Credit = 2;
        
        public SalesReceipt Receipt { get; set; }
        public double Amount { get; set; }
        
        public Payment()
        {
        }
        
        public Payment(double amount)
        {
            this.Amount = amount;
        }
    }
    
    public class PaymentType : BaseModel
    {
        public string Name { get; set; }
    }
}
