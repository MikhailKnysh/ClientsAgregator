using ClientsAgregator.Pages;
using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            AgreeWindow agree = new AgreeWindow();

            if (agree.ShowDialog() == true)
            {
                int index = gridOrders.SelectedIndex;
                gridOrders.Items.RemoveAt(index);

                int orderId = _ordersInfoModels[index].Id;

                _ordersInfoModels.RemoveAt(index);
                _controller.DeleteOrder(orderId);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _ordersInfoModels = _controller.GetOrderModels();
            foreach (var item in _ordersInfoModels)
            {
                gridOrders.Items.Add(item);
            }
        }

        private void buttonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage());
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateOrderPage(
                _ordersInfoModels[gridOrders.SelectedIndex]));
        }
    }
}
