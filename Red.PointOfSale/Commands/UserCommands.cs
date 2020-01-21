using System;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories.SQLite;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Commands
{
    public class Login: AbstractCommand
    {
        public override void Run()
        {
            var userRepo = new SQLiteUserRepository();
            var loginView = new ConsoleLoginView();
            var controller = new UserController(userRepo, loginView);
            ApplicationHelper.Show(controller.Login());
        }
    }
}
