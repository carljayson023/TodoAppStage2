using System.Collections.Generic;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Services
{
    public interface IListService
    {
        //List<string> catchResult(List<string> actionResult);
        IEnumerable<Datalist> LoadList();
       List<string> RegisterNewList(Datalist data);
        List<string> RemoveList(Datalist data);
        List<string> UpdateList(Datalist data);
        void Save();
    }
}