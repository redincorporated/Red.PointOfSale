using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories
{
    public interface ICustomerRepository
    {
        Customer ReadByCode(string code);
    }
}
