using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Database
{
    public class ConnectDB: IConnectDB
    {
        SQLiteConnection connect = new SQLiteConnection();
        public ConnectDB(SQLiteConnection _connect)
        {
            connect = _connect;
        }

        public ConnectDB()
        {
        }

        public SQLiteConnection DbConnection() // Set SQLITE Connection
        {
            string dbConnection = @"Data Source=datalist.db";
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnection);
            return sqliteCon;

        }
        public string AddData(Datalist data) // Insert Datalist
        {
            //string[] datas = data.Split('&');
            var name = data.Name;
            var description = data.Description;
            connect = DbConnection();
            connect.Open();
            string Query = "INSERT INTO Datalists(Name, Description) VALUES('" + name + "', '" + description + "')";

            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Save From DB SQLITE Query";
        }

        public string AddDataItem(Itemlist data) // -----> Insert Item
        {
          
            connect = DbConnection();
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



        public string DeleteData(string data) // { ID ,Table Name }   DELETE
        {
            string[] datas = data.Split('&');
            var id = datas[0];
            var tableName = datas[1];
            var idName = "";
            if (tableName == "Itemlists")
            {
                idName = "ItemlistId";
            }
            else { idName = "DatalistId"; }
            connect = DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "INSERT INTO @tablename where @idName = @id ";
            cmd.Parameters.AddWithValue("@tablename", tableName);
            cmd.Parameters.AddWithValue("@idName", idName);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Successfuly Deleted! From DB SQLITE Query";
        }
        public List<Datalist> GetAll() // ------> Get All DAta
        {

            connect = DbConnection();
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
        }


        public List<Itemlist> GetItem(int id) //get by ID
        {
            var listFile = new List<Itemlist>();
            connect = DbConnection();
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
        }

        public string UpdateData(Datalist data) // Update List
        {

            int id = data.DatalistId;
            string name = data.Name;
            string des = data.Description;
            connect = DbConnection();
            connect.Open();
            SQLiteCommand cmd = new SQLiteCommand(connect);
            cmd.CommandText = "UPDATE Datalists SET Name = @name , Description = @des WHERE DatalistId = " + id;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@des", des);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connect.Close();
            return "Done Update From DB SQLITE Query";
        }

        public string UpdateData(Itemlist data) // Update Item
        {

            int id = data.ItemlistId;
            string name = data.Name;
            string des = data.Detailed;
            string status = data.Status;
            connect = DbConnection();

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
