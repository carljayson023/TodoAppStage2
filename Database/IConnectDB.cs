using System.Collections.Generic;
using System.Data.SQLite;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Database
{
    public interface IConnectDB
    {
        SQLiteConnection DbConnection();
        List<Datalist> GetAll();
        List<Itemlist> GetItem(int id);
        string AddData(Datalist data);
        string AddDataItem(Itemlist data);
        string DeleteData(string data);

        string UpdateData(Datalist data);
        string UpdateData(Itemlist data);
    }
}