using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Services
{
    public class UnitOfWork
    {
        //public IItemService itemService;
        //public IListService listService;
        public UnitOfWork()//IItemService _itemService, IListService _listService)
        {
            //itemService = _itemService;
            //listService = _listService;

        }
        public string catchResult(List<string> actionResult) // ----> CatchResult Message
        {
            if (actionResult[1] == "true")
            { ListServices.Save(); ItemServices.Save(); } //-------> Saving Data

            return actionResult[0];
        }

        private ListService listServices;
        public ListService ListServices // -------> Singleton
        {
            get
            {
                if (this.listServices == null)
                {
                    this.listServices = new ListService();
                }
                return listServices;
            }
        }

        private ItemService itemServices;
        public ItemService ItemServices // -------> Singleton
        {
            get
            {
                if (this.itemServices == null)
                {
                    this.itemServices = new ItemService();
                }
                return itemServices;
            }
        }
       
        
    }
}
//https://www.youtube.com/watch?v=CRatpHRVZ3c

//-------> Factory patern -> https://www.youtube.com/watch?v=I2il8ZsDkLU