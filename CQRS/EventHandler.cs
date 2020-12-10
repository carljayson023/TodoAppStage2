using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2.CQRS
{
    public class EventHandler
    {

        //public void CommandHandler();
        //public void QueryHandler();
        private readonly IContainer container;
        private readonly IDetalistRepository listRepository;
        EventBroker broker;
        public Datalist oldData;
        
        public EventHandler(EventBroker broker)
        {
            this.broker = broker;
            broker.Queries += BrokerOnQueries;
            broker.Commands += BrokerOnCommands;
            container = App.Configure();
            listRepository = container.Resolve<IDetalistRepository>();
        }
        public void BrokerOnQueries(object sender, Query query)
        {
            var getList = query as GetAllListQuery;
            if (getList != null && getList.Target == this)
            {getList.Result = listRepository.GetAllDatalist(); }
        }
        public void BrokerOnCommands(object sender, Command command)
        {
            var cmd = command as TodoCommand;
            if (cmd != null && cmd.Target == this)
            {
                broker.AllEvent.Add(new UpdateListEvent(this, oldData, cmd.newlistData));
                oldData = cmd.newlistData;
            }
        }
        
    }
}
//------> https://www.youtube.com/watch?v=Q0Bz-O67_nI