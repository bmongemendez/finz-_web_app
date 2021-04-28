using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Interfaces
{
    public interface ICrud<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
    }
}
