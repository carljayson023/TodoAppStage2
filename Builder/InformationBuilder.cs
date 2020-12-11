using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Factory;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Builder
{
    public class InformationBuilder
    {
        //private int _Id;
        //private string _Name;
        //private string _Description;
        //private string _Detailed;
        //private string _Status;

        private DatalistRepository listRepository;
        private IItemRepository itemRepository;
        private ClassFactory classFactory;

        public InformationBuilder(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
        }
        public InformationBuilder GetItems(int id)
        {

            //itemRepository = new ItemRepository();
            itemRepository.GetAll(id);
            return this;
        }
        public InformationBuilder CountAllDoneItems(int id)
        {
            classFactory = new ConcreteFactory();

            IDataInterface CountStatus = classFactory.StatusReports("done");

            CountStatus.Status(id);// DatalistID
            //_Name = name;
            return this;
        }
        public InformationBuilder CountAllPendingItems(int id)
        {
            classFactory = new ConcreteFactory();

            IDataInterface CountStatus = classFactory.StatusReports("pending");

            CountStatus.Status(id);// DatalistID
            //_Description = des;
            return this;
        }
        
        public InformationBuilder Build()
        {
            return this;
        }
    }
}
