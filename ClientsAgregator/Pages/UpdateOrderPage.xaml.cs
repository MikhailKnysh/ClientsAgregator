using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientsAgregator.Pages
{
    public partial class UpdateOrderPage : Page
    {
        private double totalPrice;

        private ProductInfoModel _productInfoModel;
        private Controller _controller;
        private OrdersInfoModel _ordersInfoModel;
        private OrderModel _orderModel;

        private List<ClientsFullNameModel> _clients;
        private List<StatusModel> _statuses;
        private List<ProductsSubgropModel> _products;
        private List<ProductInOrderModel> _productInOrderModels;

        public UpdateOrderPage(OrdersInfoModel ordersInfoModel)
        {
            InitializeComponent();

            _ordersInfoModel = ordersInfoModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _productInOrderModels = new List<ProductInOrderModel>();

            labelPageTitle.Content += _ordersInfoModel.Id.ToString();

            _clients = _controller.GetClientsFullNameModels();
            foreach (var client in _clients)
            {
                comboBoxClient.Items.Add(client.FullName);
            }

            string fullName = $"{_ordersInfoModel.LastName} {_ordersInfoModel.FirstName} {_ordersInfoModel.MiddleName}";
            comboBoxClient.SelectedItem = fullName;

            _statuses = _controller.GetStatusModels();
            foreach (var status in _statuses)
            {
                comboBoxStatus.Items.Add(status.Title);
            }

            _orderModel = _controller.GetOrdersInfoById(_ordersInfoModel.Id);
            StatusModel statusModel = (from s in _statuses
                                       where s.Id == _orderModel.StatusesId
                                       select s).FirstOrDefault();

            //StatusModel statusModel = _statuses.FirstOrDefault(s => s.Id == _orderModel.StatusesId);
            comboBoxStatus.SelectedItem = statusModel.Title;

            _products = _controller.GetProductsSubgroupModels();
            foreach (var product in _products)
            {
                comboBoxProduct.Items.Add(product.ProductTitle);
            }

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfOrdersWindow());
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductInOrderModel productInOrderModel = new ProductInOrderModel()
            {
                Articul = _productInfoModel.Articul,
                ProductId = _productInfoModel.Id,
                ProductTitle = _productInfoModel.Title,
                Price = _productInfoModel.Price,
                Quantity = Convert.ToInt32(textBoxQuaunity.Text),
                MeasureUnitId = _productInfoModel.MeasureUnitId,
                MeasureUnitTitle = _productInfoModel.MeasureUnit,
                GroupTitle = _productInfoModel.Group,
                SubgroupTitle = _productInfoModel.Subgroup,
                Rate = -1
            };

            _productInOrderModels.Add(productInOrderModel);

            totalPrice += productInOrderModel.Price * productInOrderModel.Quantity;
            textBoxTotalPrice.Text = totalPrice.ToString();

            gridProductsInOrder.Items.Add(productInOrderModel);
        }

        private void comboBoxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            AgreeWindow agreeWindow = new AgreeWindow();

            if (agreeWindow.ShowDialog() == true)
            {
                int index = gridProductsInOrder.SelectedIndex;

                totalPrice -= _productInOrderModels[index].Price * _productInOrderModels[index].Quantity;
                textBoxTotalPrice.Text = totalPrice.ToString();

                gridProductsInOrder.Items.RemoveAt(index);
                _productInOrderModels.RemoveAt(index);
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
