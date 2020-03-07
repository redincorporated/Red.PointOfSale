using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlItemDetailRepository : BaseMySqlRepository<ItemDetail>, IItemDetailRepository
    {
        public MySqlItemDetailRepository()
        {
        }
        
        public ItemDetail ReadByCode(string code)
        {
            string query = @"
select id.stock_no,
    id.code,
    id.price,
    i.id,
    i.name
from item_details id
inner join items i on i.id = id.item_id
where id.code = @code";
            ItemDetail detail =  null;
            using (var rs = ExecuteReader(query, new MySqlParameter("@code", code))) {
                while (rs.Read()) {
                    detail = new ItemDetail {
                        StockNumber = GetString(rs, 0),
                        Code = GetString(rs, 1),
                        Price = GetDouble(rs, 2),
                        Item = new Item {
                            Id = GetInt32(rs, 3),
                            Name = GetString(rs, 4)
                        }
                    };
                }
            }
            return detail;
        }
        
        public override int Save(ItemDetail detail)
        {
            string query = @"
insert into item_details(id, item_id, stock_no, code, price)
values(@id, @item_id, @stock_no, @code, @price);
select last_insert_id()";
            return (int)ExecuteScalar(
                query,
                new MySqlParameter("@id", detail.Id),
                new MySqlParameter("@item_id", detail.Item.Id),
                new MySqlParameter("@stock_no", detail.StockNumber),
                new MySqlParameter("@code", detail.Code),
                new MySqlParameter("@price", detail.Price));
        }
        
        public override ItemDetail Read(int id)
        {
            string query = @"
select stock_no, code, price
from item_details
where id = @id";
            ItemDetail detail = null;
            using (var rs = ExecuteReader(query, new MySqlParameter("@id", id))) {
                if (rs.Read()) {
                    detail = new ItemDetail {
                        StockNumber = GetString(rs, 0),
                        Code = GetString(rs, 1),
                        Price = GetDouble(rs, 2)
                    };
                }
            }
            return detail;
        }
        
        public override void Update(ItemDetail detail, int id)
        {
            string query = @"
update item_details set item_id = @item_id,
stock_no = @stock_no,
code = @code,
price = @price
where id = @id";
            ExecuteNonQuery(
                query,
                new MySqlParameter("@id", detail.Id),
                new MySqlParameter("@item_id", detail.Item.Id),
                new MySqlParameter("@stock_no", detail.StockNumber),
                new MySqlParameter("@code", detail.Code),
                new MySqlParameter("@price", detail.Price));
        }
        
        public List<ItemDetail> FindByItem(int itemId)
        {
            string query = @"
select stock_no, code, price
from item_details
where item_id = @item_id";
            var details = new List<ItemDetail>();
            using (var rs = ExecuteReader(query, new MySqlParameter())) {
                while (rs.Read()) {
                    var detail = new ItemDetail {
                        StockNumber = GetString(rs, 0),
                        Code = GetString(rs, 1),
                        Price = GetDouble(rs, 2)
                    };
                    details.Add(detail);
                }
            }
            return details;
        }
    }
}
