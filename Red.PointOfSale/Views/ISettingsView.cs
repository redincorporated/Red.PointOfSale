using System;

namespace Red.PointOfSale.Views
{
    public interface ISettingsView : IView
    {
        event EventHandler ItemsSync;
    }
}
