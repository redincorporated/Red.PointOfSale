using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories
{
    public interface IUserRepository
    {
        User ReadByUsernameAndPassword(string username, string password);
    }
}
