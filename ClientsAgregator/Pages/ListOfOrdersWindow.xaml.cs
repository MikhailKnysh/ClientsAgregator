using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
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

namespace ClientsAgregator
{
    public partial class ListOfOrdersWindow : Page
    {
        private Controller _controller;
        List<OrdersInfoModel> _ordersInfoModels; 
        
        public ListOfOrdersWindow()
        {
            InitializeComponent();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = ProductsGrid.SelectedIndex;
            ProductsGrid.Items.RemoveAt(index);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _ordersInfoModels = _controller.GetOrderModels();
            foreach (var item in _ordersInfoModels)
            {
                ProductsGrid.Items.Add(item);
            }
            //ProductsGrid.ItemsSource = _productInfoModels;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddingOfProductWindow addingOfProductWindow = new AddingOfProductWindow();
            //addingOfProductWindow.Show();
            //this.Close();
        }
    }
}
