﻿using System;
using System.Windows.Forms;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Repositories.SQLite;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Commands
{
    public class ShowSettings : AbstractCommand
    {
        public override void Run()
        {
            var repoFactory = RepositoryFactory.GetRepositoryFactory();
            var itemRepo = repoFactory.CreateItemRepository();
            
            var viewFactory = ViewFactory.GetViewFactory();
            var settingsView = viewFactory.CreateSettingsView();
            
            var controller = new AppController(settingsView, itemRepo);
            ApplicationHelper.Show(controller.Settings());
        }
    }
}
