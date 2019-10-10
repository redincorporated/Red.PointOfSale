using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Repositories.SQLite;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;
using Red.PointOfSale.Helpers;

namespace Red.PointOfSale
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainForm.Instance.AddChild(Login());
            Application.Run(MainForm.Instance);
        }

        static SQLiteItemRepository itemRepo = new SQLiteItemRepository();
        static SQLiteUserRepository userRepo = new SQLiteUserRepository();

        static LoginPane Login()
        {
            var loginView = new LoginPane();
            loginView.Login += delegate (object sender, UserEventArgs e) {
                var user = userRepo.ReadByUsernameAndPassword(e.User.Username, e.User.Password);
                if (user != null) {
                    MainForm.Instance.AddChild(new DepartmentsPane());
                } else {
                    MessageHelper.ShowWarning("Invalid username or password. Please try again.");
                }
            };
            return loginView;
        }

        static SalesReceiptPane Sales()
        {
            var salesReceiptView = new SalesReceiptPane();
            salesReceiptView.ItemSearch += delegate (object sender, ItemEventArgs e) {
                var item = itemRepo.ReadByCode(e.Item.Code);
                if (item != null) {
                    salesReceiptView.AddItem(item);
                }
            };
            return salesReceiptView;
        }

        static ConfigurationPane Settings()
        {
            var configView = new ConfigurationPane();
            return configView;
        }
    }
}
