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
    }
}
