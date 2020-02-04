using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class SQLiteCustomerRepository : ICustomerRepository
    {
        public Customer ReadByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
