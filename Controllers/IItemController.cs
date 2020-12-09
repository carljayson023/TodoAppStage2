using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Controllers
{
    interface IItemController
    {
        string AddItem_Class(Itemlist data);
        string DeleteItem_Class(Itemlist data);
        string UpdateItem_Class(object data);
    }
}