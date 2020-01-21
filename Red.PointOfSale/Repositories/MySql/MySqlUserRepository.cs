using System;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlUserRepository : IUserRepository
    {
        public MySqlUserRepository()
        {
        }
        
        public User ReadByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
