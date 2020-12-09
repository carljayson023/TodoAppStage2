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
using ToDoApp_v1._2.Controllers;
using ToDoApp_v1._2.Database;
using ToDoApp_v1._2.Model;
using ToDoApp_v1._2.Repository;
using ToDoApp_v1._2.Services;

namespace ToDoApp_v1._2
{
   
   
    public partial class CreateItemForm : Window
    {
        
        public int _ItemId { get; set; }
        public string _ItemNames { get; set; }
        public string _ItemDetail { get; set; }
        public string _ItemStatuz { get; set; }
        public int _ItemDataListId { get; set; }

        //private readonly DataDbContext _context = new DataDbContext();

        //Information info;
        //ItemController _itemController = new ItemController();

        //IConnectDB _connectDb;
        //private readonly App app = new App();
        private readonly IContainer container;
    
        public CreateItemForm(/*IConnectDB condb*/)
        {
         
            container = App.Configure();
            
            InitializeComponent();
        }
        private void Cancel(object s, RoutedEventArgs e) // Cancel Or Close Windows Form
        {
            this.Close();
        }

        private void AddItem(object s, RoutedEventArgs e)  // Adding new item To the List
        {
            //var container = App.Configure();
            
            var unitOfWork = container.Resolve<UnitOfWork>();

            string _ItemName = ItemName.Text;
            string _ItemDetailed = ItemDetailed.Text;
            string _ItemStatus = cbox_status.Text;

            if (_ItemName.Trim() != "" && _ItemDetailed.Trim() != "" && _ItemStatus.Trim() != "")
            {
                if (_ItemId != 0)
                {
                    //------------------------------------------------ Update
                    var ItemToUpdate = new Itemlist {
                                        ItemlistId = _ItemId,
                                        Name = _ItemName,
                                        Detailed = _ItemDetailed,
                                        Status = _ItemStatus,
                                        DatalistId = _ItemDataListId
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ItemServices.UpdateItem(ItemToUpdate));
                    MessageBox.Show(result);

                    //MessageBox.Show(_itemController.UpdateItem_Class(ItemToUpdate)); 

                    //MessageBox.Show(_connectDb.Update(ItemToUpdate));
                    //var result = unitOfWork.catchResult(unitOfWork.UpdateItem(ItemToUpdate));
                    //if (result[1] == "true") { unitOfWork.Save(); }
                    //MessageBox.Show(result[0]);
                }
                else
                {
                    // ----------------------------------------------------------- Add ITEM
                    var addingItem = new Itemlist { Name = _ItemName,
                                                    Detailed = _ItemDetailed, 
                                                    Status = _ItemStatus, 
                                                    DatalistId = _ItemDataListId
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ItemServices.RegisterNewItem(addingItem));
                    MessageBox.Show(result);
                    //MessageBox.Show(_itemController.AddItem_Class(addingItem));
                    //MessageBox.Show(addingItem.Name+ "-"+ addingItem.Detailed);
                    //MessageBox.Show(_connectDb.Add(addingItem));
                    //unitOfWork.RegisterNewItem(addingItem);
                    //unitOfWork.Save();
                    //MessageBox.Show("New Item Successfully Added");

                    //var result = unitOfWork.catchResult(unitOfWork.RegisterNewItem(addingItem));
                    //if (result[1] == "true") { unitOfWork.Save(); }
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
            
            cbox_status.Text = _ItemStatuz;
            ItemName.Text = _ItemNames;
            ItemDetailed.Text = _ItemDetail;
        }
    }
}
