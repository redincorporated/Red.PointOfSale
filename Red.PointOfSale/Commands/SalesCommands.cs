using System;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Commands
{
    public class CreateSales : AbstractCommand
    {
        public override void Run()
        {
            var v = new ConsoleSalesReceiptView();
            var c = new SalesReceiptController(v);
            c.Add();
        }
    }
}
