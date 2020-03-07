using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Red.PointOfSale.Services;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories.SQLite;

namespace Red.PointOfSale.Gui
{
    public partial class ConfigurationPane : UserControl
    {
        public ConfigurationPane()
        {
            InitializeComponent();

            service.ResponseReceived += Service_ResponseReceived;
        }

        SQLiteUserRepository userRepo = new SQLiteUserRepository();

        private void Service_ResponseReceived(object sender, ResponseEventArgs e)
        {
            if (e.Response.Data is List<User>) {
                foreach (var u in e.Response.Data as List<User>) {
                    userRepo.SaveOrUpdate(u);
                }
            }
        }

        ApiService service = new ApiService(ConfigurationManager.AppSettings["pos-backend-url"], ConfigurationManager.AppSettings["pos-backend-apikey"]);

        private void button1_Click(object sender, EventArgs e)
        {
            service.PullUsers();
        }
    }
}
