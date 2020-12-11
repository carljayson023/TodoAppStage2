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

        Datalist Newlist;
        private readonly IUnitOfWork unitofWork;
       
        public CreateListForm(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
            //container = App.Configure();
            InitializeComponent();
            NewListGrid.DataContext = Newlist = new Datalist();
        }
        private void Cancel(object s, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddList(object s, RoutedEventArgs e)
        {
         
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
               
                    var result = unitofWork.catchResult(unitofWork.ListServices.UpdateList(updateDataList));
                    MessageBox.Show(result);
                }
                else
                {
                    var result = unitofWork.catchResult( unitofWork.ListServices.RegisterNewList(Newlist));
                    MessageBox.Show(result);
            
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
    