using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2.CQRS
{
    public class GetItemsByIdQuery
    {
        private readonly IContainer container;
        private readonly UnitOfWork unitofWrok;
        public GetItemsByIdQuery()
        {
            container = App.Configure();
            unitofWrok = container.Resolve<UnitOfWork>();
        }
        public IEnumerable<Itemlist> GetItemById(int data)
        {

            return unitofWrok.ItemServices.LoadItem(data);
        }
    }
}
