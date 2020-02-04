using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Red.PointOfSale.Repositories.MySql
{
    public class BaseMySqlRepository<T> : BaseRepository<T>
    {
        public BaseMySqlRepository() : base(new MySqlConnection(ConfigurationManager.AppSettings["mysql-connection"]))
        {
        }
    }
}
