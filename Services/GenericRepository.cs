using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Services
{
    public class GenericRepository<T> where T : class
    {
        //internal SchoolContext context;
        //internal DbSet<T> dbSet;
        private readonly IConnectDB context;
        private SQLiteConnection connect;
        
        public GenericRepository(IConnectDB _context)
        {
            context = _context;
            connect = new SQLiteConnection();
        }
        //internal IConnectDB connect;
        //internal DbSet<T> dbSet;


        public virtual IEnumerable<T> Get()
        {
            connect = context.DbConnection();
            connect.Open();




            string Query = "Select * from Datalists";
            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            //if (data == "Datalists")
            //{
            var listFile = new List<Datalist>();
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
            var result = ((IEnumerable)listFile).Cast<object>().ToList();
            return (IEnumerable<T>)result;
            //}
            //else
            //{

            //    var listFile = new List<Itemlist>();
            //    while (rd.Read())
            //    {

            //        listFile.Add(new Itemlist()
            //        {
            //            ItemlistId = rd.GetInt32(0),
            //            Name = rd.GetString(1),
            //            Detailed = rd.GetString(2),
            //            Status = rd.GetString(3)
            //            // etc... (0, 1 refer to the column index)
            //        });
            //    }
            //    connect.Close();
            //    return listFile;
            //}


        }
        public virtual IEnumerable<Itemlist> GetItem()
        {
            connect = context.DbConnection();
            connect.Open();
            List<T> _listFile = new List<T>();

            string Query = "Select * from Itemlists";
            SQLiteCommand cmd = new SQLiteCommand(Query, connect);
            SQLiteDataReader rd = cmd.ExecuteReader();

            var listFile = new List<Itemlist>();
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

        public virtual T GetByID(object id)
        {
            throw new NotImplementedException();
            //return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            throw new NotImplementedException();
            //dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            throw new NotImplementedException();
            //T entityToDelete = dbSet.Find(id);
            //Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            //if (context.Entry(entityToDelete).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entityToDelete);
            //}
            //dbSet.Remove(entityToDelete);
            throw new NotImplementedException();
        }

        public virtual string Update(T entityToUpdate)
        {
            throw new NotImplementedException();
            //var list = new List<T>();
            //list.Add(entityToUpdate);
            //context.UpdateData(list);
            //return "";
            //dbSet.Attach(entityToUpdate);
            //context.Entry(entityToUpdate).State = EntityState.Modified;
        }


    }
}
