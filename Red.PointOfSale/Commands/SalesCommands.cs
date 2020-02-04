using System;
using System.Configuration;
using System.Windows.Forms;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Repositories.MySql;

namespace Red.PointOfSale.Commands
{
    public class CreateSales : AbstractCommand
    {
        public override void Run()
        {
            string config = ConfigurationManager.AppSettings["repository"];
            var factory = RepositoryFactory.GetRepositoryFactory(config);
            var itemRepo = factory.CreateItemRepository();
            var customerRepo = factory.CreateCustomerRepository();
            var controller = new SalesReceiptController(itemRepo, customerRepo);
            ApplicationHelper.Show(controller.Create());
        }
    }
}
