using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.CQRS
{
    class UpdateListEvent : Event
    {
        public EventHandler Target;
        public Datalist newlistData, oldListData;
        public UpdateListEvent(EventHandler target, Datalist newdata, Datalist oldData)
        {
            Target = target;
            newlistData = newdata;
            oldListData = oldData;
            //unitofWrok.ListServices.UpdateList(data);
        }
        public override string ToString()
        {
            return $"Datalist from {oldListData} to {newlistData}";
        }
    }
}
