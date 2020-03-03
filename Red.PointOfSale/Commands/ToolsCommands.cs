using System;
using System.Windows.Forms;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Repositories.SQLite;

namespace Red.PointOfSale.Commands
{
    public class ShowSettings : AbstractCommand
    {
        public override void Run()
        {
            var v = new SettingsPane();
            var r = new SQLiteItemRepository();
            var c = new AppController(v, r);
            MainForm.Instance.AddDialog(c.Settings() as Control);
        }
    }
}
