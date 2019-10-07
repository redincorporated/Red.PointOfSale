using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.PointOfSale.Models;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class SQLiteUserRepository : BaseSQLiteRepository
    {
        public User ReadByUsernameAndPassword(string username, string password)
        {
            User u = null;
            string query = @"
select id, username, password
from users
where username = @username";
            using (var rs = ExecuteReader(query, new SQLiteParameter("@username", username))) {
                if (rs.Read()) {
                    u = new User {
                        Id = GetInt32(rs, 0),
                        Username = GetString(rs, 1),
                        Password = GetString(rs, 2)
                    };
                }
            }
            if (u != null && BCrypt.Net.BCrypt.Verify(password, u.Password)) {
                return u;
            }
            return null;
        }

        public User ReadByUsername(string username)
        {
            string query = @"
select id, username, password, email, name, phone
from users
where username = @username";
            User u = null;
            using (var rs = ExecuteReader(query, new SQLiteParameter("@username", username))) {
                if (rs.Read()) {
                    u = new User {
                        Id = GetInt32(rs, 0),
                        Username = GetString(rs, 1),
                        Password = GetString(rs, 2),
                        Email = GetString(rs, 3),
                        Name = GetString(rs, 4),
                        Phone = GetString(rs, 5)
                    };
                }
            }
            return u;
        }

        public void Save(User user)
        {
            string query = @"
insert into users(username, password, email, name, phone)
values(@username, @password, @email, @name, @phone)";
            ExecuteNonQuery(query
                , new SQLiteParameter("@username", user.Username)
                , new SQLiteParameter("@password", user.Password)
                , new SQLiteParameter("@email", user.Email)
                , new SQLiteParameter("@name", user.Name)
                , new SQLiteParameter("@phone", user.Phone));
        }

        public void Update(User user, int id)
        {
            string query = @"
update users set username = @username,
password = @password,
email = @email,
phone = @phone,
name = @name
where id = @id";
            ExecuteNonQuery(query
                , new SQLiteParameter("@id", user.Id)
                , new SQLiteParameter("@username", user.Username)
                , new SQLiteParameter("@password", user.Password)
                , new SQLiteParameter("@email", user.Email)
                , new SQLiteParameter("@name", user.Name)
                , new SQLiteParameter("@phone", user.Phone));
        }

        public void SaveOrUpdate(User user)
        {
            if (ReadByUsername(user.Username) != null) {
                Update(user, user.Id);
            } else {
                Save(user);
            }
        }
    }
}
