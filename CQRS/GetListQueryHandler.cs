using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.CQRS
{
    public class GetListQueryHandler<Datalist> : GetAllListQuery
    {
        public List<Datalist> EventLog = new List<Datalist>();
    }
}
