using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Factory
{
    public class ConcreteFactory : ClassFactory
    {
        public override IDataInterface StatusReports(string type)
        {

            switch (type)
            {
                case "done":
                    return new ItemDone();
                case "pending":
                    return new ItemPending();
                default:
                    throw new ApplicationException(string.Format("Not available", type));
            }
           
            //throw new NotImplementedException();
        }

    }
}
