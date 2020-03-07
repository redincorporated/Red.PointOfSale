using System;
using System.Collections.Generic;
using Red.PointOfSale.Models;
using Red.PointOfSale.Repositories;

namespace Red.PointOfSale.Services
{
    public class ItemService
    {
        IItemRepository itemRepo;
        IItemDetailRepository itemDetailRepo;
        
        public ItemService(IItemRepository itemRepo, IItemDetailRepository itemDetailRepo)
        {
            this.itemRepo = itemRepo;
            this.itemDetailRepo = itemDetailRepo;
        }
        
        public void Save(List<Item> items)
        {
            foreach (var item in items) {
                Save(item);
            }
        }
        
        public void Save(Item item)
        {
            SaveOrUpdate(item);
            foreach (var d in item.Details) {
                SaveOrUpdate(d);
            }
        }
        
        void SaveOrUpdate(ItemDetail detail)
        {
            var x = itemDetailRepo.Read(detail.Id);
            if (x == null) {
                itemDetailRepo.Save(detail);
            } else {
                itemDetailRepo.Update(detail, detail.Id);
            }
        }
        
        void SaveOrUpdate(Item item)
        {
            var x = itemRepo.Read(item.Id);
            if (x == null) {
                itemRepo.Save(item);
            } else {
                itemRepo.Update(item, item.Id);
            }
        }
    }
}
