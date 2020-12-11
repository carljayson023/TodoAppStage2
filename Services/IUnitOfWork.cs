using System.Collections.Generic;

namespace ToDoApp_v1._2.Services
{
    public interface IUnitOfWork
    {
        IItemService ItemServices { get; }
        IListService ListServices { get; }

        string catchResult(List<string> actionResult);
    }
}