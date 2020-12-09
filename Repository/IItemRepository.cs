using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Itemlist> GetAll(int id);
        string Add(Itemlist data);
        string Update(Itemlist data);
        void Delete(int id);
      
    }
}
