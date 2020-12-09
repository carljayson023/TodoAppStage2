using ToDoApp_v1._2.Model;

namespace ToDoApp_v1._2.Controllers
{
    public interface IListController
    {
        string AddList_Class(Datalist data);
        string DeleteList_Class(Datalist data);
        string UpdateList_Class(object data);
    }
}