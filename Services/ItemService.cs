using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;

namespace ToDoApp_v1._2.Services
{
    public class ItemService : IItemService
    {
        private ItemRepository itemRepository;
        private readonly List<Itemlist> newItem = new List<Itemlist>();
        private readonly List<Itemlist> updateItem = new List<Itemlist>();
        private readonly List<Itemlist> removeItem = new List<Itemlist>();
        private readonly List<Itemlist> ItemContainer = new List<Itemlist>();
        private List<string> result = new List<string>();
        struct Message
        {
            public string msgs;
            public string validate;
        }
        public IEnumerable<Itemlist> LoadItem(int Id) // ------> Load all Item to Container
        {

            itemRepository = new ItemRepository();
            ItemContainer.AddRange(itemRepository.GetAll(Id));

            return ItemContainer;
        }
        public List<string> RegisterNewItem(Itemlist data) // -----------------> Insert new item
        {
            Message Msg;
            LoadItem(data.DatalistId);
            if (data.ItemlistId == 0 && !ItemContainer.Contains(data))
            {
                newItem.Add(data);

                Msg.msgs = "New Item Successfully Added!!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Data Already Registered.!!!";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public List<string> UpdateItem(Itemlist data) //--------------------------> Update new Item
        {
            Message Msg;
            LoadItem(data.DatalistId);
            if (data.ItemlistId != 0 && !ItemContainer.Contains(data))
            {
                updateItem.Add(data);
                Msg.msgs = "Item Successfully Updated!!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Request an Update Failed. Please try Again.!! ";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public List<string> RemoveItem(Itemlist data) //------------------------------------- >> Remove Item
        {
            Message Msg;
            LoadItem(data.DatalistId);
            if (data.ItemlistId != 0 )
            {
                removeItem.Add(data);
                Msg.msgs = "Your Request Has Been Successfull. Item has been Remove.!";
                Msg.validate = "true";
            }
            else
            {
                Msg.msgs = "Failed to Remove the Item";
                Msg.validate = "false";
            }

            result = new List<string> { Msg.msgs, Msg.validate };
            return result;

        }
        public void Save()
        {
            
            //--- Save Item
            if (newItem != null)
            {
                foreach (Itemlist item in newItem)
                {
                    itemRepository.Add(item);
                }
            }
            if (updateItem != null)
            {
                foreach (Itemlist update in updateItem)
                {
                    itemRepository.Update(update);
                }
            }
            if (removeItem != null)
            {
                foreach (Itemlist remove in removeItem)
                {
                    itemRepository.Delete(remove.ItemlistId);
                }
            }

            Dispose();
        }
        public void Dispose()
        {
           
            newItem.Clear();
            updateItem.Clear();
            removeItem.Clear();
            ItemContainer.Clear();
        }
    }
}
