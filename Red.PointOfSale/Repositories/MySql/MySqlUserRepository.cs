using System;
using MySql.Data.MySqlClient;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.MySql
{
    public class MySqlUserRepository : BaseMySqlRepository<User>, IUserRepository
    {
        public MySqlUserRepository()
        {
        }
        
        public User ReadByUsernameAndPassword(string username, string password)
        {
            string query = @"
select username, password
from users
where username = @username
and password = @password";
            User u = null;
            using (var rs = ExecuteReader(query, new MySqlParameter("@username", username), new MySqlParameter("@password", password))) {
                if (rs.Read()) {
                    u = new User(GetString(rs, 0), GetString(rs, 1));
                }
            }
            return u;
        }
    }
}
