using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IListService listServices;
        private readonly IItemService itemServices;
        public UnitOfWork(IListService _listServices, IItemService _itemServices)//IItemService _itemService, IListService _listService)
        {
            itemServices = _itemServices;
            listServices = _listServices;

        }
        public string catchResult(List<string> actionResult) // ----> CatchResult Message
        {
            if (actionResult[1] == "true")
            { ListServices.Save(); ItemServices.Save(); } //-------> Saving Data

            return actionResult[0];
        }
        public IListService ListServices // -------> Singleton
        {
            get
            {
                //if (this.listServices == null)
                //{
                //    this.listServices = listServices;
                //}
                return listServices;
            }
        }


        public IItemService ItemServices // -------> Singleton
        {
            get
            {
                //if (this.itemServices == null)
                //{
                //    this.itemServices = itemServices;
                //}
                return itemServices;
            }
        }


    }
}
//https://www.youtube.com/watch?v=CRatpHRVZ3c

//-------> Factory patern -> https://www.youtube.com/watch?v=I2il8ZsDkLU