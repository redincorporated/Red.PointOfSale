using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Views
{
    public interface ISalesReceiptView : IView
    {
        event EventHandler<ItemEventArgs> ItemSearch;
        event EventHandler<CustomerEventArgs> CustomerSearch;
        void AddItem(Item item);
    }
}
