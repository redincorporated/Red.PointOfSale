using System;
using System.Collections.Generic;
using System.Data;

namespace Red.PointOfSale.Repositories
{
    public interface IBaseRepository<T>
    {
        int Save(T t);
        void Update(T t, int id);
        void Delete(int id);
        T Read(int id);
        List<T> FindAll();
    }
    
    public class BaseRepository<T> : IBaseRepository<T>
    {
        IDbConnection conn;
        
        public BaseRepository(IDbConnection conn)
        {
            this.conn = conn;
        }
        
        public virtual int Save(T t)
        {
            throw new NotImplementedException();
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

        protected void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed) {
                conn.Open();
            }
        }

        protected double GetDouble(IDataReader rs, int index)
        {
            return GetDouble(rs, index, 0);
        }

        protected double GetDouble(IDataReader rs, int index, double _default)
        {
            return !rs.IsDBNull(index) ? rs.GetDouble(index) : _default;
        }

        protected DateTime GetDateTime(IDataReader rs, int index)
        {
            return GetDateTime(rs, index, DateTime.MinValue);
        }

        protected DateTime GetDateTime(IDataReader rs, int index, DateTime _default)
        {
            return !rs.IsDBNull(index) ? rs.GetDateTime(index) : _default;
        }

        protected int GetInt32(IDataReader rs, int index)
        {
            return GetInt32(rs, index, 0);
        }

        protected int GetInt32(IDataReader rs, int index, int _default)
        {
            return !rs.IsDBNull(index) ? rs.GetInt32(index) : _default;
        }

        protected string GetString(IDataReader rs, int index)
        {
            return GetString(rs, index, "");
        }

        protected string GetString(IDataReader rs, int index, string _default)
        {
            return !rs.IsDBNull(index) ? rs.GetString(index) : _default;
        }

        protected object ExecuteScalar(string query, params IDbDataParameter[] parameters)
        {
            var cmd = conn.CreateCommand();
            OpenConnection();
            cmd.CommandText = query;
            foreach (var param in parameters) {
                cmd.Parameters.Add(param);
            }
            var returnValue = cmd.ExecuteScalar();
            CloseConnection();
            return returnValue;
        }

        protected void ExecuteNonQuery(string query, params IDbDataParameter[] parameters)
        {
            var cmd = conn.CreateCommand();
            OpenConnection();
            cmd.CommandText = query;
            foreach (var param in parameters) {
                cmd.Parameters.Add(param);
            }
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        protected IDataReader ExecuteReader(string query, params IDbDataParameter[] parameters)
        {
            var cmd = conn.CreateCommand();
            OpenConnection();
            cmd.CommandText = query;
            foreach (var param in parameters) {
                cmd.Parameters.Add(param);
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open) {
                conn.Close();
            }
        }
    }
}
