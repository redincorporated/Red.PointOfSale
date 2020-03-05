using System;
using System.Configuration;
using Red.PointOfSale.Repositories.MySql;
using Red.PointOfSale.Repositories.SQLite;

namespace Red.PointOfSale.Repositories
{
    public abstract class RepositoryFactory
    {
        public const string MySql = "mysql";
        public const string SQLite = "sqlite";
        
        public RepositoryFactory()
        {
        }
        
        public static IRepositoryFactory GetRepositoryFactory()
        {
            return GetRepositoryFactory(ConfigurationManager.AppSettings["sql-repository"]);
        }
        
        public static IRepositoryFactory GetRepositoryFactory(string type)
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
        IItemRepository CreateItemRepository();
        ICustomerRepository CreateCustomerRepository();
    }
    
    public class MySqlRepositoryFactory : RepositoryFactory, IRepositoryFactory
    {
        public IUserRepository CreateUserRepository()
        {
            return new MySqlUserRepository();
        }
        
        public IItemRepository CreateItemRepository()
        {
            return new MySqlItemRepository();
        }
        
        public ICustomerRepository CreateCustomerRepository()
        {
            return new MySqlCustomerRepository();
        }
    }
    
    public class SQLiteRepositoryFactory : RepositoryFactory, IRepositoryFactory
    {
        public IUserRepository CreateUserRepository()
        {
            return new SQLiteUserRepository();
        }
        
        public IItemRepository CreateItemRepository()
        {
            return new SQLiteItemRepository();
        }
        
        public ICustomerRepository CreateCustomerRepository()
        {
            return new SQLiteCustomerRepository();
        }
    }
}
