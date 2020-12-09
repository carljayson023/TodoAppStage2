using System.Collections.Generic;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Services
{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(object id);
        void Delete(T entityToDelete);
        IEnumerable<Datalist> Get();
        T GetByID(object id);
        IEnumerable<Itemlist> GetItem();
        void Insert(T entity);
        void Update(T entityToUpdate);
    }
}