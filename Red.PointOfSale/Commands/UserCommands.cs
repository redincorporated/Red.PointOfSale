using System;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Repositories.SQLite;

namespace Red.PointOfSale.Commands
{
    public class Login: AbstractCommand
    {
        public Login()
        {
        }
        
        public override void Run()
        {
            MainForm.Instance.AddChild(new LoginPane());
        }
    }
}
