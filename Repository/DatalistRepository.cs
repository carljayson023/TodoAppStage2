using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Repository
{
    public class DatalistRepository : IDatalistRepository
    {
        private readonly IConnectDB context;
        private SQLiteConnection connect;

        public DatalistRepository(IConnectDB _context)
        {
            context = _context;
            connect = new SQLiteConnection();
        }

        public IEnumerable<Datalist> GetAllDatalist() // Get all Data
        {
            connect = context.DbConnection();
            connect.Open();
            //List<string> listFile = new List<string>();
            var listFile = new List<Datalist>();


            string Query = "Select * from Datalists";
            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                listFile.Add(new Datalist()
                {
                    DatalistId = rd.GetInt32(0),
                    Name = rd.GetString(1),
                    Description = rd.GetString(2)
                });

            }
            connect.Close();
            return listFile;
            //throw new NotImplementedException();
        }
     

        public string Add(Datalist data) // Add to Datalist table
        {
            var name = data.Name;
            var description = data.Description;

            connect = context.DbConnection();
            connect.Open();
            string Query = "INSERT INTO Datalists(Name, Description) VALUES('" + name + "', '" + description + "')";

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";
            //throw new NotImplementedException();
        }

        public string Update(Datalist data)  // --------------> Update
        {
            int id = data.DatalistId;
            string name = data.Name;
            string des = data.Description;
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "UPDATE Datalists SET Name = @name , Description = @des WHERE DatalistId = " + id;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@des", des);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Update Succcessfully";
            //throw new NotImplementedException();
        }
        public string Find(Datalist data)
        {
            return "";
        }
        public string Find(Itemlist data)
        {
            return "";
        }

        public void Delete(int id) // -------------------> delete datalist
        {
            //string[] datas = data.Split('&');
            //var id = datas[0];
            //var tableName = datas[1];
            //var idName = "";
            //if (tableName == "Itemlists")
            //{
            //    idName = "ItemlistId";
            //}
            //else { idName = "DatalistId"; }
            connect = context.DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "DELETE FROM Datalists where DatalistId = @id ";
            
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            //return "Successfuly Deleted! From DB SQLITE Query";
            //throw new NotImplementedException();
        }

        
    }
}
