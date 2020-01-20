using System;
using MySql.Data.MySqlClient;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlItemRepository : BaseMySqlRepository<Item>, IItemRepository
    {
        public MySqlItemRepository()
        {
        }
        
        public Item ReadByCode(string code)
        {
            string query = @"
select code
from items
where code = @code";
            Item item = null;
            using (var rs = ExecuteReader(query, new MySqlParameter("@code", code))) {
                if (rs.Read()) {
                    item = new Item {
                        Code = GetString(rs, 0),
                    };
                }
            }
            return item;
        }
    }
}
