using System;
using System.Windows.Forms;
using Red.PointOfSale.Commands;
using Red.PointOfSale.Controllers;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Helpers
{
    public class ApplicationHelper
    {
        public ApplicationHelper()
        {
        }
        
        public static string GetVersion()
        {
            return Application.ProductVersion;
//            var v = new Version(Application.ProductVersion);
//            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }
        
        public static void Show(IView view)
        {
            application.Show(view);
        }
        
        static IApplication application;
        
        public static void Attach(IApplication application)
        {
            ApplicationHelper.application = application;
        }
        
        public static void Run()
        {
            application.Run();
        }
    }
    
    public class WindowsApplication : IApplication
    {
        public WindowsApplication()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
        
        public void Run()
        {
            Application.Run(MainForm.Instance);
        }
        
        public void Show(IView view)
        {
            MainForm.Instance.AddChild(view as Control);
        }
    }
    
    public interface IApplication
    {
        void Run();
        void Show(IView view);
    }
}
