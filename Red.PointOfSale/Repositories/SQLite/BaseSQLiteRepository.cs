using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.PointOfSale.Repositories.SQLite
{
    public class BaseSQLiteRepository<T>: BaseRepository<T>
    {
        public BaseSQLiteRepository() : base(new SQLiteConnection(ConfigurationManager.AppSettings["sqlite-connection"]))
        {
        }
    }
}
