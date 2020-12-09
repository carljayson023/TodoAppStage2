using System.Collections.Generic;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Controllers
{
    interface IDataController
    {
        string AddData(Datalist data);
        string AddData(Itemlist data);
        string DeleteData(Datalist data);
        string DeleteData(Itemlist data);
        List<Datalist> GetAllList();
        List<Itemlist> GetItem(int id);
        string UpdateData(Datalist data);
        string UpdateData(Itemlist data);
    }
}