using System;
using MySql.Data.MySqlClient;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlSalesReceiptRepository : BaseMySqlRepository<SalesReceipt>, ISalesReceiptRepository
    {
        public MySqlSalesReceiptRepository()
        {
        }
        
        public override int Save(SalesReceipt receipt)
        {
            string query = @"
insert into sales_receipts(date, customer_id)
values(@id, @customer_id);
select last_insert_id()";
            return (int)ExecuteScalar(
                query,
                new MySqlParameter("@date", receipt.Date),
                new MySqlParameter("@customer_id", receipt.Customer.Id));
        }
    }
}
