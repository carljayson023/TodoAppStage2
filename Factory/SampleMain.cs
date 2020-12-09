using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Factory
{
    public class SampleMain
    {
        ClassFactory classFactory;
        public SampleMain(ConcreteFactory _classFactory)
        {
            classFactory = _classFactory;

            IDataInterface CountStatus = classFactory.StatusReports("done");

            CountStatus.Status(1);// DatalistID

            
        }
        
    }

}
