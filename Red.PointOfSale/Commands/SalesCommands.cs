﻿using System;
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
            var repoFactory = RepositoryFactory.GetRepositoryFactory();
            var itemRepo = repoFactory.CreateItemRepository();
            var customerRepo = repoFactory.CreateCustomerRepository();
            
            var viewFactory = ViewFactory.GetViewFactory();
            var salesReceiptView = viewFactory.CreateSalesReceiptView();
            
            var controller = new SalesReceiptController(itemRepo, customerRepo, salesReceiptView);
            ApplicationHelper.Show(controller.Create());
        }
    }
}
