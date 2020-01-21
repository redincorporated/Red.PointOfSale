using System;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Repositories.SQLite;

namespace Red.PointOfSale.Repositories
{
    public class AbstractRepositoryFactory
    {
        public const int MySql = 1;
        public const int SQLite = 0;
        
        public AbstractRepositoryFactory()
        {
        }
        
        public static IRepositoryFactory GetrepositoryFactory(int type)
        {
            switch (type) {
                    case MySql: return new MySqlRepositoryFactory();
                    default: return new SQLiteRepositoryFactory();
            }
        }
    }
    
    public interface IRepositoryFactory
    {
        IUserRepository CreateUserRepository();
    }
    
    public class MySqlRepositoryFactory : AbstractRepositoryFactory, IRepositoryFactory
    {
        public IUserRepository CreateUserRepository()
        {
            return new MySqlUserRepository();
        }
    }
    
    public class SQLiteRepositoryFactory : AbstractRepositoryFactory, IRepositoryFactory
    {
        public IUserRepository CreateUserRepository()
        {
            return new SQLiteUserRepository();
        }
    }
}
