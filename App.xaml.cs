using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp_v1._2.Controllers;
using ToDoApp_v1._2.CQRS;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2
{

    public partial class App : Application
    {
        //private void OnStartup(object sender, StartupEventArgs e)
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<DataDbContext>().AsSelf();
        //    builder.RegisterType<ItemController>().As<IItemController>();
        //    builder.RegisterType<DatalistRepository>().As<IDetalistRepository>();
        //    //builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerLifetimeScope();

        //    // Add the MainWindowclass and later resolve

        //    builder.RegisterType<MainWindow>().AsSelf();

        //    var container = builder.Build();

        //    using (var scope = container.BeginLifetimeScope())
        //    {
        //        var window = scope.Resolve<MainWindow>();
        //        window.Show();
        //    }

        //    return builder.Build();
        //}

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<ItemController>().As<IItemController>();
            //builder.RegisterType<ListController>().As<IListController>();
            builder.RegisterType<DatalistRepository>().As<IDetalistRepository>();
            builder.RegisterType<ItemRepository>().As<IItemRepository>();
            builder.RegisterType<DataController>().As<IDataController>();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<CreateItemForm>().AsSelf();
            builder.RegisterType<CreateListForm>().AsSelf();
            builder.RegisterType<DataDbContext>().AsSelf();
            builder.RegisterType<UnitOfWork>().AsSelf();
            builder.RegisterType<ListService>().As<IListService>();
            builder.RegisterType<ItemService>().As<IItemService>();
            builder.RegisterType<ListController>().As<IListController>();
            builder.RegisterType<GetAllListQuery>().AsSelf();
            builder.RegisterType<GetAllListHandler>().AsSelf();


            //builder.RegisterType<ConnectDB>().As<IConnectDB>();

            builder.RegisterAssemblyTypes()
                .Where(t => t.Namespace.Contains("Model"))
                .AsSelf();

            builder.RegisterAssemblyTypes()
                .Where(t => t.Namespace.Contains("Repository"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();


        }
        private void OnStartup(object sender, StartupEventArgs e)
        {

            var container = Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindows = scope.Resolve<MainWindow>();
                mainWindows.Show();
            }
        }


    }
}
