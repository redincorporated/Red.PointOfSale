using Red.PointOfSale.Repositories.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Services
{
    public class SalesReceiptService
    {
        SQLiteSalesReceiptRepository salesReceiptRepo;
        SQLiteItemRepository itemRepo;
        SQLiteUserRepository userRepo;

        public SalesReceiptService(
            SQLiteSalesReceiptRepository salesReceiptRepo, 
            SQLiteItemRepository itemRepo,
            SQLiteUserRepository userRepo)
        {
            this.salesReceiptRepo = salesReceiptRepo;
            this.itemRepo = itemRepo;
            this.userRepo = userRepo;
        }

        public User ReadUserByUsernameAndPassword(string username, string password)
        {
            return userRepo.ReadByUsernameAndPassword(username, password);
        }

        public Item ReadItemByCode(string code)
        {
            return itemRepo.ReadByCode(code);
        }

        public void SaveSalesReceipt(SalesReceipt receipt)
        {
            salesReceiptRepo.Save(receipt);
        }
    }
}
