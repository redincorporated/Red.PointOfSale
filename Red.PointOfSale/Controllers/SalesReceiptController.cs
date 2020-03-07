using System;
using System.Windows.Forms;
using Red.PointOfSale.Gui;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Services;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Controllers
{
    public class SalesReceiptController
    {
        ItemService itemService;
        ICustomerRepository customerRepo;
        ISalesReceiptView salesReceiptView;

        public SalesReceiptController(ItemService itemService, ICustomerRepository customerRepo, ISalesReceiptView salesReceiptView)
        {
            this.itemService = itemService;
            this.customerRepo = customerRepo;
            this.salesReceiptView = salesReceiptView;
        }
        
        public IView Create()
        {
            salesReceiptView.ItemSearch += delegate(object sender, ItemEventArgs e) { 
                var itemDetail = itemService.ReadByCode(e.Item.Code);
                if (itemDetail != null) {
                    salesReceiptView.AddItem(itemDetail.Item);
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
