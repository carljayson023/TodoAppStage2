using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2.CQRS
{
    public class GetAllListQuery : Query
    {
        public EventHandler Target;
        private readonly IContainer container;
        private readonly UnitOfWork unitofWrok;

        public GetAllListQuery()
        {
            container = App.Configure();
            unitofWrok = container.Resolve<UnitOfWork>();
        }
        public IEnumerable<Datalist> GetAllTodo()
        {
            //GetListQueryHandler<Datalist> events = new GetListQueryHandler<Datalist>(); 
            //events.EventLog.Add(unitofWrok.ListServices.LoadList());
            return unitofWrok.ListServices.LoadList();

        }
    }
}
