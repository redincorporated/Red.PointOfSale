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
        
        public override int Save(Item item)
        {
            string query = @"
insert into items(id, name, description)
values(@id, @name, @description);
select last_insert_id();";
            return (int)ExecuteScalar(
                query,
                new MySqlParameter("@id", item.Id),
                new MySqlParameter("@name", item.Name),
                new MySqlParameter("@description", item.Description)
            );
        }
        
        public override void Update(Item item, int id)
        {
            string query = @"
update items set name = @name,
description = @description
where id = @id";
            ExecuteNonQuery(
                query,
                new MySqlParameter("@id", item.Id),
                new MySqlParameter("@name", item.Name),
                new MySqlParameter("@description", item.Description)
            );
        }
        
        public override Item Read(int id)
        {
            string query = @"
select code, name, description, price
from items
where id = @id";
            Item item = null;
            using (var rs = ExecuteReader(query, new MySqlParameter("@id", id))) {
                if (rs.Read()) {
                    item = new Item {
                        Code = GetString(rs, 0),
                        Name = GetString(rs, 1),
                        Description = GetString(rs, 2),
                        Price = GetDouble(rs, 3),
                    };
                }
            }
            return item;
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
