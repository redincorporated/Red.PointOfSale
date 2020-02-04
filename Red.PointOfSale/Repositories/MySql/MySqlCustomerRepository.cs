using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlCustomerRepository : ICustomerRepository
    {
        public Customer ReadByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
