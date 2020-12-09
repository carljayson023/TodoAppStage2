using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Controllers
{
    class DataController : IDataController
    // --------------------------------------------->> Overloading Ex.
    {
        private readonly DataDbContext _context = new DataDbContext();

        public List<Datalist> GetAllList()
        {
            var data = _context.Datalists.ToList();
            return data;
        }
        public List<Itemlist> GetItem(int id)
        {
            var data = _context.Itemlists.Where(i => i.DatalistId == id).ToList();
            return data;
        }

        public string AddData(Datalist data)
        {
            _context.Datalists.Add(data);
            _context.SaveChanges();
            return "";
        }
        public string AddData(Itemlist data)
        {
            _context.Itemlists.Add(data);
            _context.SaveChanges();
            return "";
        }
        public string UpdateData(Datalist data)
        {

            _context.Update(data);
            _context.SaveChanges();
            return "Update Successfully!";
        }
        public string UpdateData(Itemlist data)
        {

            _context.Update(data);
            _context.SaveChanges();
            return "Update Successfully!";
        }

        public string DeleteData(Datalist data)
        {
            try
            {
                _context.Datalists.Remove(data);
                _context.SaveChanges();
                return data.Name + "Successfuly Deleted.";
            }
            catch
            {
                return "Item Failed to Delete.!";
            }
        }
        public string DeleteData(Itemlist data)
        {
            try
            {
                _context.Itemlists.Remove(data);
                _context.SaveChanges();
                return data.Name + "Successfuly Deleted.";
            }
            catch
            {
                return "Item Failed to Delete.!";
            }
        }
    }
}
