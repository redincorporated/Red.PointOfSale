using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class SQLiteItemDepartmentRepository : BaseSQLiteRepository
    {
        public List<ItemDepartment> FindAll()
        {
            var departments = new List<ItemDepartment>();
            string query = @"
select id, name
from item_departments";
            using (var rs = ExecuteReader(query)) {
                while (rs.Read()) {
                    departments.Add(new ItemDepartment {
                        Id = GetInt32(rs, 0),
                        Name = GetString(rs, 1)
                    });
                }
            }
            return departments;
        }
    }
}
