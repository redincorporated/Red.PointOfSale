using System;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;

namespace Red.PointOfSale.Commands
{
    public class Login: AbstractCommand
    {
        public override void Run()
        {
            var c = new UserController();
            MainForm.Instance.AddChild(c.Login());
        }
    }
}
