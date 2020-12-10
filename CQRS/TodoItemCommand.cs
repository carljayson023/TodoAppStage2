using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2.CQRS
{
    public class TodoItemCommand
    {
        private readonly IContainer container;
        private readonly UnitOfWork unitofWrok;
        public TodoItemCommand()
        {
            container = App.Configure();
            unitofWrok = container.Resolve<UnitOfWork>();
        }
        public void CreateTodoItem(Itemlist data)
        {
            unitofWrok.ItemServices.RegisterNewItem(data); 
        }
        public void UpdateTodoItem(Itemlist data)
        {
            unitofWrok.ItemServices.UpdateItem(data);
        }
        public void DeleteTodoItem(Itemlist data)
        {
            unitofWrok.ItemServices.RemoveItem(data);
        }
    }
}
