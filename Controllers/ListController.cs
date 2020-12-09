
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using ToDoApp_v1._2.Model;
//using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Controllers
{
    public class ListController : IListController
    {
        private readonly DataDbContext _context = new DataDbContext();
        public string AddList_Class(Datalist data)
        {
            
            _context.Datalists.Add(data);
            //_context.Datalists.Find("");
            _context.SaveChanges();
            return "New Data Successfully Added!!";
        }
        public string UpdateList_Class(object data)
        {
            _context.Entry(data).State = EntityState.Modified;
            //_context.Update(data);
            _context.SaveChanges();
            return "Data Updated Successfully!";

        }

        public string DeleteList_Class(Datalist data)
        {
            try
            {
                _context.Datalists.Remove(data);
                _context.SaveChanges();
                return $"{data.Name} Has Successfully Deleted";
            }
            catch
            {
                return "Failed To Delete.!";
            }
        }
    }
}
