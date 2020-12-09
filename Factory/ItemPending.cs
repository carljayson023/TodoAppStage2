using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ToDoApp_v1._2.Database;

namespace ToDoApp_v1._2.Factory
{
    public class ItemPending : IDataInterface
    {
        private readonly ConnectDB context;
        private SQLiteConnection connect = new SQLiteConnection();
        public ItemPending()
        {
            context = new ConnectDB();
        }
        public int Status(int Id)
        {
            //var listFile = new List<Itemlist>();
            connect = context.DbConnection();
            connect.Open();
            string Query = "SELECT Count(*) From Itemlists Where Status = 'Pending'";

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            var TotalNumberOfPending = (int)cmd.ExecuteScalar();

            return TotalNumberOfPending;
            //throw new NotImplementedException();
        }
    }
}
