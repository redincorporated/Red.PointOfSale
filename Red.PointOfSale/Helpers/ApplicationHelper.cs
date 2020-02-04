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
    
    public class ConsoleApplication : IApplication
    {
        public void Run()
        {
            new CreateSales().Run();
        }
        
        public void Show(IView view)
        {
        }
        
        void ShowMenu()
        {
            Console.Write(@"
  1 Sales Entry
  2

> ");
        }
    }
    
    public class WindowsApplication : IApplication
    {
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
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
