using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Views
{
    public interface ILoginView : IView
    {
        event EventHandler<UserEventArgs> Login;
        void PerformLogin(string username, string password);
        void Reset();
    }
}
