using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T obj);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void UpdateItem(T obj);
        void Delete(T obj);
    }
}
