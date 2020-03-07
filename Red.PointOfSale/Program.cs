using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red.PointOfSale.Commands;
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
            
            ApplicationHelper.Attach(new WindowsApplication());
            
            new CreateSales().Run();
            ApplicationHelper.Run();
        }
    }
}
