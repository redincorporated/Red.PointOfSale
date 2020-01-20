using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class SQLiteSalesReceiptRepository : BaseSQLiteRepository<SalesReceipt>
    {
        public List<SalesReceipt> FindUnposted()
        {
            var receipts = new List<SalesReceipt>();
            string query = @"
select id, date, customer_id
from sales_receipts
where status = @status";
            using (var rs = ExecuteReader(query, new SQLiteParameter("@status", SalesReceipt.Pending))) {
                while (rs.Read()) {
                    receipts.Add(new SalesReceipt {
                        Id = GetInt32(rs, 0),
                        Date = GetDateTime(rs, 1),
                        Customer = new Customer { Id = GetInt32(rs, 2) }
                    });
                }
            }
            foreach (var s in receipts) {
                s.AddItems(FindItems(s.Id));
            }
            return receipts;
        }

        public List<SalesReceiptItem> FindItems(int salesReceiptId)
        {
            var items = new List<SalesReceiptItem>();
            string query = @"
select id, sales_receipt_id, item_id, quantity, price
from sales_receipt_items
where sales_receipt_id = @sales_receipt_id";
            using (var rs = ExecuteReader(query, new SQLiteParameter("@sales_receipt_id", salesReceiptId))) {
                while (rs.Read()) {
                    items.Add(new SalesReceiptItem {
                        Id = GetInt32(rs, 0),
                        Item = new Item { Id = GetInt32(rs, 2) },
                        Quantity = GetDouble(rs, 3),
                        Price = GetDouble(rs, 4)
                    });
                }
            }
            return items;
        }

        public int Save(SalesReceipt receipt)
        {
            int salesReceiptId = 0;
            return salesReceiptId;
        }

        public void SaveItem(SalesReceiptItem item)
        {

        }
    }
}
