using System;
using System.Windows.Forms;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Controllers
{
    public class SalesReceiptController
    {
        IItemRepository itemRepo;
        ICustomerRepository customerRepo;
        ISalesReceiptView salesReceiptView;

        public SalesReceiptController(IItemRepository itemRepo, ICustomerRepository customerRepo)
        {
            this.itemRepo = itemRepo;
            this.customerRepo = customerRepo;
        }
        
        public IView Create()
        {
            salesReceiptView.ItemSearch += delegate(object sender, ItemEventArgs e) { 
                var item = itemRepo.ReadByCode(e.Item.Code);
                if (item != null) {
                    salesReceiptView.AddItem(item);
                } else {
                    
                }
            };
            salesReceiptView.CustomerSearch += delegate(object sender, CustomerEventArgs e) { 
                var customer = customerRepo.ReadByCode(e.Customer.Code);
                if (customer != null) {
                    // TODO:
                } else {
                    
                }

            };
            return salesReceiptView;
        }
    }
}
