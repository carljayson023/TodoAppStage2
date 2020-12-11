using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Services
{
    public class ListService : IListService
    {
        private IDatalistRepository listRepository;
        private readonly List<Datalist> newList = new List<Datalist>();
        private readonly List<Datalist> updateList = new List<Datalist>();
        private readonly List<Datalist> removeList = new List<Datalist>();
        private readonly List<Datalist> ListContainer = new List<Datalist>();
        private List<string> result = new List<string>();
        public ListService(IDatalistRepository _listRepository)
        {
            listRepository = _listRepository;
        }
        struct Message
        {
            public string msgs;
            public string validate;
        }
        //public List<string> catchResult(List<string> actionResult) // ----> CatchResult Message
        //{
        //    //var actionResult = msg.Split("&");
        //    var result = new List<string> { actionResult[0], actionResult[1] };
        //    return result;
        //}
        public IEnumerable<Datalist> LoadList() // ------> Load all List to Container
        {

            //listRepository = new DatalistRepository();
            ListContainer.AddRange(listRepository.GetAllDatalist());

            return ListContainer;
        }


        public List<string> RegisterNewList(Datalist data) //------------ Register New List
        {

            Message Msg;
            Msg.validate = "true";
            if (data.DatalistId == 0 && !ListContainer.Contains(data))
            {
                newList.Add(data);
                Msg.msgs = "New List Ssuccessfully Added!!!";
               
            }
            else
            {
                Msg.msgs = "Data Already Registered.!!!";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };

            //var result = msg + "&" + validate;
            
            return result;
        }
        public List<string> UpdateList(Datalist data) //---------------------->> Update
        {
            Message Msg;
            Msg.validate = "true";
            if (data.DatalistId != 0 && !ListContainer.Contains(data))
            {
                updateList.Add(data);
                Msg.msgs = "List Ssuccessfully Updatedss!!!";
            }
            else
            {
                Msg.msgs = "Data Cant Update Please Try Again!!! ";
                Msg.validate = "false";
            }
            result = new List<string> { Msg.msgs, Msg.validate };
            //var result = msg + "&" + validate;
            return result;
        }
        public List<string> RemoveList(Datalist data) // -------->> Remove
        {
            Message Msg;
            Msg.validate = "true";
            if (data.DatalistId != 0 )
            {
                removeList.Add(data);
                Msg.msgs = "List has been Successfully Remove!";
                Msg.validate = "true";

            }
            else
            {
                Msg.msgs = "Sorry Your Request is Failed to Remove!";
                Msg.validate = "false";
            }
            result = new List<string> { Msg.msgs, Msg.validate };
            //var result = msg + "&" + validate;
            return result;
        }
        public void  Save()
        {
            //---Save List
            if (newList != null)
            {

                foreach (Datalist newlist in newList)
                {
                    listRepository.Add(newlist);
                }
            }
            if (updateList != null)
            {
                foreach (Datalist update in updateList)
                {
                    listRepository.Update(update);
                }
            }
            if (removeList != null)
            {
                foreach (Datalist remove in removeList)
                {
                    listRepository.Delete(remove.DatalistId);
                }
            }
            //return newList;


            Dispose();
            //context.SaveChanges();
        }
        public void Dispose()
        {
            newList.Clear();
            updateList.Clear();
            removeList.Clear();
           
            ListContainer.Clear();
            
        }
    }
}
