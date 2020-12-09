using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Factory
{
    public abstract class ClassFactory
    {
        //IDataInterface<Datalist> datalist = new TodoList<Datalist>();

        //public ClassFactory()
        //{
        //    datalist.GetAll();

        //    var updateDataList = new Datalist
        //    {

        //        Name = "",
        //        Description = ""
        //    };
        //    datalist.Insert(updateDataList);
        //}
        public abstract IDataInterface StatusReports(string type);
    }
}
