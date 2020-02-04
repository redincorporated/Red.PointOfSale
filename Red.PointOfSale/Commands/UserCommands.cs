using System;
using System.Configuration;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Repositories.SQLite;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Commands
{
    public class Login: AbstractCommand
    {
        public Login()
        {
        }
        
        public override void Run()
        {
            string repo = ConfigurationManager.AppSettings["repository"];
            string view = ConfigurationManager.AppSettings["view"];
            var userRepo = RepositoryFactory.GetRepositoryFactory(repo).CreateUserRepository();
            var loginView = ViewFactory.GetViewFactory(view).CreateLoginView();
            var controller = new UserController(userRepo, loginView);
            ApplicationHelper.Show(controller.Login());
        }
    }
}
