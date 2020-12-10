using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp_v1._2.CQRS
{
    public class EventBroker
    {
        public IList<Event> AllEvent = new List<Event>();
        

        public event EventHandler<Command> Commands;
        public event EventHandler<Query> Queries;

        public void Command(Command cmd)
        {
            Commands?.Invoke(this, cmd);
        }
        public T Query<T>(Query query)
        {
            Queries?.Invoke(this, query);
            return (T)query.Result;
        }
    }
}
