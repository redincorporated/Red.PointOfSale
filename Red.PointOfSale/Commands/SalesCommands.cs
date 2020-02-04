using System;
using System.Configuration;
using System.Windows.Forms;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Commands
{
    public class CreateSales : AbstractCommand
    {
        public override void Run()
        {
            string repo = ConfigurationManager.AppSettings["sql-repository"];
            string view = ConfigurationManager.AppSettings["view"];
            var factory = RepositoryFactory.GetRepositoryFactory(repo);
            var itemRepo = factory.CreateItemRepository();
            var customerRepo = factory.CreateCustomerRepository();
            var salesReceiptView = ViewFactory.GetViewFactory(view).CreateSalesReceiptView();
            var controller = new SalesReceiptController(itemRepo, customerRepo, salesReceiptView);
            ApplicationHelper.Show(controller.Create());
        }
    }
}
