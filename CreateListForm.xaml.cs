using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Controllers;
using ToDoApp_v1._2.Database;

using ToDoApp_v1._2.Repository;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2
{
    
    public partial class CreateListForm : Window
    {
        public int _ListId { get; set; }
        public string _ListName { get; set; }
        public string _ListDescription { get; set; }

        //private readonly DataDbContext _context = new DataDbContext();
        //private readonly IConnectDB _connectDb;//= new ConnectDB();
        private readonly Autofac.IContainer container;
        Datalist Newlist = new Datalist();
        
        //----->> Class And Object
        //ListController _listController = new ListController(); // Call and Set Controller for ADD UPDATE DELETE 
        public CreateListForm()
        {
            container = App.Configure();
            InitializeComponent();
            NewListGrid.DataContext = Newlist;
        }
        private void Cancel(object s, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddList(object s, RoutedEventArgs e)
        {
            //var container = App.Configure();
            //var _connectDb = container.Resolve<IDetalistRepository>();
            var unitofWork = container.Resolve<UnitOfWork>();
            //MessageBox.Show(_ListId.ToString());
            if (ListDescription.Text.Trim() != "" && ListName.Text.Trim() != "")
            {
                if (_ListId != 0) 
                {
                    var updateDataList = new Datalist
                    {
                        DatalistId = _ListId,
                        Name = ListName.Text,
                        Description = ListDescription.Text
                    };
                    //_listController._GetAllList();
                    //MessageBox.Show("Data has Successfuly Updated");
                    //MessageBox.Show(_listController.UpdateList_Class(updateDataList)); // Update Data by Manual
                    //MessageBox.Show(_connectDb.Update(updateDataList));
                    //MessageBox.Show(unitofWork.ListRepository.Update(updateDataList));


                    //var result = unitofWork.catchResult(unitofWork.UpdateList(updateDataList));
                    //if (result[1] == "true")
                    //{ unitofWork.Save(); }

                    //MessageBox.Show(result[0]);

                    var result = unitofWork.catchResult(unitofWork.ListServices.UpdateList(updateDataList));
                    MessageBox.Show(result);
                }
                else
                {
                    //MessageBox.Show(_listController.GetAllList().ToString());
                    //MessageBox.Show(_listController.AddList_Class(Newlist)); // Add Data by Binding
                    //MessageBox.Show(_connectDb.Add(Newlist));
                    //MessageBox.Show(unitofWork.ListRepository.Add(Newlist));
                    var result = unitofWork.catchResult( unitofWork.ListServices.RegisterNewList(Newlist));
                    MessageBox.Show(result);
                    //ListService service = new ListService();
                    //var result = unitofWork.catchResult(unitofWork.RegisterNewList(Newlist));
                    //if (result[1] == "true")
                    //{  service.Save(); }
                    //MessageBox.Show(result[0]);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Fill Up All Boxes!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListName.Text = _ListName;
            ListDescription.Text = _ListDescription;
        }
    }
}
    