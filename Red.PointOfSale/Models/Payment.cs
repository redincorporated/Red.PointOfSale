using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Models
{
    public class Payment : BaseModel
    {
        public SalesReceipt Receipt { get; set; }
        public double Amount { get; set; }
    }
}
