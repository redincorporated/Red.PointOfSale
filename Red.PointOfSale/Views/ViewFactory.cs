using System;
using Red.PointOfSale.Gui;

namespace Red.PointOfSale.Views
{
    public abstract class ViewFactory
    {
        const string Windows = "windows";
        
        public ViewFactory()
        {
        }
        
        public static IViewFactory GetViewFactory(string type)
        {
            switch (type) {
                    default: return new WindowViewFactory();
            }
        }
    }
    
    public interface IViewFactory
    {
        ILoginView CreateLoginView();
    }
    
    public class WindowViewFactory : IViewFactory
    {
        public ILoginView CreateLoginView()
        {
            return new LoginPane();
        }
    }
}
