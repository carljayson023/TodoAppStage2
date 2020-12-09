using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ConnectDB context;
        private SQLiteConnection connect = new SQLiteConnection();
        public ItemRepository()
        {
            context = new ConnectDB();
        }
        public string Add(Itemlist data) //-------------------------> Insert Item
        {
            connect = context.DbConnection();
            //string Query = "INSERT INTO Itemlists(Name, Detailed,Status,DatalistId) VALUES('" + datas[0] + "', '" + datas[1] + "',)";
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "INSERT INTO Itemlists(Name, Detailed,Status,DatalistId) VALUES(@name,@detailed,@status,@datalistId)";
            cmd.Parameters.AddWithValue("@name", data.Name);
            cmd.Parameters.AddWithValue("@detailed", data.Detailed);
            cmd.Parameters.AddWithValue("@status", data.Status);
            cmd.Parameters.AddWithValue("@datalistId", data.DatalistId);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";
           
        }

        public void Delete(int id)
        {
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "DELETE FROM Itemlists Where ItemlistId = @id ";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public IEnumerable<Itemlist> GetAll(int id) //--------------------------------> Get All Itemm By Id
        {
            var listFile = new List<Itemlist>();
            connect = context.DbConnection();
            connect.Open();
            string Query = "SELECT * From Itemlists Where DatalistId = " + id;

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();
         
            while (rd.Read())
            {

                listFile.Add(new Itemlist()
                {
                    ItemlistId = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Detailed = rd.GetString(2),
                    Status = rd.GetString(3)
                    // etc... (0, 1 refer to the column index)
                });
            }
            connect.Close();
            return listFile;
            //throw new NotImplementedException();
        }

       

        public string Update(Itemlist data) //------------------------------>> Update
        {
            int id = data.ItemlistId;
            string name = data.Name;
            string des = data.Detailed;
            string status = data.Status;
            connect = context.DbConnection();

            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "UPDATE Itemlists SET Name = @name , Detailed = @des, Status = @status WHERE ItemlistId = " + id;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@des", des);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Update From DB SQLITE Query";
        }
    }
}
