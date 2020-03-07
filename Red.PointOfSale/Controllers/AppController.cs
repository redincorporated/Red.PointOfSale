using System;
using System.Collections.Generic;
using System.Configuration;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;
using Red.PointOfSale.Services;
using Red.PointOfSale.Views;

namespace Red.PointOfSale.Controllers
{
    public class AppController
    {
        ISettingsView settingsView;
        ApiService apiService;
//        IItemRepository itemRepo;
        ItemService itemService;
        
//        public AppController(ISettingsView settingsView, IItemRepository itemRepo)
        public AppController(ISettingsView settingsView, ItemService itemService)
        {
//            this.itemRepo = itemRepo;
            this.settingsView = settingsView;
            string url = ConfigurationManager.AppSettings["pos-backend-url"];
            string token = ConfigurationManager.AppSettings["pos-backend-token"];
            apiService = new ApiService(url, token);
            
            apiService.ResponseReceived += delegate(object sender, ResponseEventArgs e) { 
                if (e.Response.Data is List<Item>) {
                    foreach (var item in (e.Response.Data as List<Item>)) {
                        itemService.Save(item);
//                        if (itemRepo.Read(i.Id) != null) {
//                            itemRepo.Update(i, i.Id);
//                        } else {
//                            itemRepo.Save(i);
//                        }
                    }
                } else {
                    Console.WriteLine(e.Response.Message);
                }
            };
        }
        
        public IView Settings()
        {
            settingsView.ItemsSync += delegate(object sender, EventArgs e) { 
                apiService.PullItems();
            };
            return settingsView;
        }
    }
}
