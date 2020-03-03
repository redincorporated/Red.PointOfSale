using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class SQLiteItemRepository : BaseSQLiteRepository<Item>, IItemRepository
    {
        public Item ReadByCode(string code)
        {
            string query = @"
select id, code, name, price
from items
where code = @code";
            Item i = null;
            using (var rs = ExecuteReader(query, new SQLiteParameter("@code", code))) {
                if (rs.Read()) {
                    i = new Item {
                        Id = GetInt32(rs, 0),
                        Code = GetString(rs, 1),
                        Name = GetString(rs, 2),
                        Price = GetDouble(rs, 3)
                    };
                }
            }
            return i;
        }

        public Item Read(int id)
        {
            string query = @"
select id, code, name, price
from items
where id = @id";
            Item i = null;
            using (var rs = ExecuteReader(query, new SQLiteParameter("@id", id))) {
                if (rs.Read()) {
                    i = new Item {
                        Id = GetInt32(rs, 0),
                        Code = GetString(rs, 1),
                        Name = GetString(rs, 2),
                        Price = GetDouble(rs, 3)
                    };
                }
            }
            return i;
        }

        public void Save(Item item)
        {
            string query = @"
insert into items(id, code, name, description, price)
values(@id, @code, @name, @description, @price)";
            ExecuteNonQuery(query
                , new SQLiteParameter("@id", item.Id)
                , new SQLiteParameter("@code", item.Code)
                , new SQLiteParameter("@name", item.Name)
                , new SQLiteParameter("@description", item.Description)
                , new SQLiteParameter("@price", item.Price));
        }

        public void Update(Item item, int id)
        {
            string query = @"
update items set code = @code,
name = @name,
description = @description,
price = @price
where id = @id";
            ExecuteNonQuery(query
                , new SQLiteParameter("@code", item.Code)
                , new SQLiteParameter("@name", item.Name)
                , new SQLiteParameter("@description", item.Description)
                , new SQLiteParameter("@id", id)
                , new SQLiteParameter("@price", item.Price));
        }

        public void SaveOrUpdate(Item item)
        {
            if (Read(item.Id) != null) {
                Update(item, item.Id);
            } else {
                Save(item);
            }
        }

        public void SaveJournal(ItemJournal journal)
        {
            string query = @"
insert into item_journals(item_id, date, quantity_in, quantity_out)
values(@item_id, @date, @quantity_in, @quantity_out)";
            ExecuteNonQuery(query
                , new SQLiteParameter("@item_id", journal.Item.Id)
                , new SQLiteParameter("@date", journal.Date)
                , new SQLiteParameter("@quantity_in", journal.QuantityIn)
                , new SQLiteParameter("@quantity_out", journal.QuantityOut));
        }
    }
}
