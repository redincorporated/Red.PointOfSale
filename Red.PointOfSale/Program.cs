using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Repositories.SQLite;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;
using Red.PointOfSale.Helpers;
using Red.PointOfSale.Services;

namespace Red.PointOfSale
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainForm.Instance.AddChild(Sales());
            Application.Run(MainForm.Instance);
        }

        static SalesReceiptService service = new SalesReceiptService(
            new SQLiteSalesReceiptRepository(),
            new SQLiteItemRepository(),
            new SQLiteUserRepository());

        static LoginPane Login()
        {
            var view = new LoginPane();
            view.Login += delegate (object sender, UserEventArgs e) {
                var user = service.ReadUserByUsernameAndPassword(e.User.Username, e.User.Password);
                if (user != null) {
                    MainForm.Instance.AddChild(new DepartmentsPane());
                } else {
                    MessageHelper.ShowWarning("Invalid username or password. Please try again.");
                }
            };
            return view;
        }

        static SalesReceiptPane Sales()
        {
            var view = new SalesReceiptPane();
            view.ItemSearch += delegate (object sender, ItemEventArgs e) {
                var item = service.ReadItemByCode(e.Item.Code);
                if (item != null) {
                    view.AddItem(item);
                }
            };
            view.Save += delegate (object sender, SalesReceiptEventArgs e) {
                service.SaveSalesReceipt(e.Receipt);
            };
            return view;
        }

        static ConfigurationPane Settings()
        {
            var configView = new ConfigurationPane();
            return configView;
        }
    }
}
