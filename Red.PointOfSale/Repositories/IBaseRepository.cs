using System;
using System.Collections.Generic;

namespace Red.PointOfSale.Repositories
{
    public interface IBaseRepository<T>
    {
        void Save(T t);
        void Update(T t, int id);
        void Delete(int id);
        T Read(int id);
        List<T> FindAll();
    }
}
