using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2.CQRS
{
    //public event EventHandler
    public class TodoCommand : Command
    {
       
        public EventHandler Target;
        public Datalist newlistData;

        public TodoCommand(EventHandler target, Datalist data)
        {
            Target = target;
            newlistData = data;
        }
        //public void CreateTodo(EventHandler target, Datalist data)
        //{
            
            //unitofWrok.ListServices.RegisterNewList(data);

        //}
        //public void UpdateTodo(EventHandler target, Datalist newdata, Datalist oldData)
        //{
        //    Target = target;
        //    newlistData = newdata;
        //    oldListData = oldData;
        //    //unitofWrok.ListServices.UpdateList(data);
        //}
        //public void DeleteTodo(Datalist data)
        //{
        //    unitofWrok.ListServices.RemoveList(data);
        //}
    }
}
