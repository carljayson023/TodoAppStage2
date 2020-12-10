using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.CQRS
{
    public class OutputSample
    {
        
        public OutputSample()
        {
            var eventBroker = new EventBroker();
            var _event = new EventHandler(eventBroker);
            List<Datalist> addData = new List<Datalist>();
           
            Datalist Addlist = new Datalist();
            Addlist.DatalistId = 1;
            Addlist.Name = "new name";
            Addlist.Description = "new description";

            eventBroker.Command(new TodoInsertCommand(_event, Addlist));
        }
    }
}
