using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Red.PointOfSale.Repositories.MySql
{
    public class BaseMySqlRepository<T> : IBaseRepository<T>
    {
        IDbConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["mysql-connection"]);
        
        public BaseMySqlRepository()
        {
        }
        
        public string GetString(IDataReader rs, int index)
        {
            return GetString(rs, index, "");
        }
        
        public string GetString(IDataReader rs, int index, string @default)
        {
            return !rs.IsDBNull(index) ? rs.GetString(index) : @default;
        }
        
        public IDataReader ExecuteReader(string query, params IDbDataParameter[] parameters)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = query;
            foreach (var p in parameters) {
                cmd.Parameters.Add(p);
            }
            OpenConnection();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        
        protected void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed) {
                conn.Open();
            }
        }
        
        protected void CloseConnection()
        {
            if (conn.State == ConnectionState.Open) {
                conn.Close();
            }
        }
        
        public virtual void Save(T t)
        {
        }
        
        public virtual void Update(T t, int id)
        {
        }
        
        public virtual void Delete(int id)
        {
        }
        
        public virtual T Read(int id)
        {
            throw new NotImplementedException();
        }
        
        public virtual List<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
