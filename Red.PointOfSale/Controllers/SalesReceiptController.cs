using System;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Controllers
{
    public class SalesReceiptController
    {
        ISalesReceiptView view;
        
        public SalesReceiptController(ISalesReceiptView view)
        {
            this.view = view;
        }
        
        public IView Add()
        {
            return view;
        }
    }
}
