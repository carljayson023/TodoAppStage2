using System.Collections.Generic;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Services
{
    public interface IItemService
    {
        IEnumerable<Itemlist> LoadItem(int Id);
        List<string> RegisterNewItem(Itemlist data);
        List<string> RemoveItem(Itemlist data);
        List<string> UpdateItem(Itemlist data);
        void Save();
    }
}