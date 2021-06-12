using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientsAgregator.Pages
{
    /// <summary>
    /// Interaction logic for AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private List<ClientsFullNameModel> _clients;
        private List<StatusModel> _statuses;
        private List<ProductsSubgropModel> _products;
        private List<ProductInOrderModel> _productInOrderModels;
        private ProductInfoModel productInfoModel;
        private double totalPrice;

        private Controller _controller;

        public AddOrderPage()
        {
            InitializeComponent();
            _controller = new Controller();
            _productInOrderModels = new List<ProductInOrderModel>();
        }


        private void AddOrderPage_Loaded(object sender, RoutedEventArgs e)
        {
            _clients = _controller.GetClientsFullNameModels();
            foreach (var client in _clients)
            {
                comboBoxClient.Items.Add(client.FullName);
            }

            _statuses = _controller.GetStatusModels();
            foreach (var status in _statuses)
            {
                comboBoxStatus.Items.Add(status.Title);
            }

            _products = _controller.GetProductsSubgroupModels();
            foreach (var product in _products)
            {
                comboBoxProduct.Items.Add(product.ProductTitle);
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string quantity = textBoxQuaunity.Text.Trim();

            bool isAdding = true;

            if (!(ValidationData.IsNumber(quantity) 
                || !(ValidationData.IsValidStringLenght(quantity, validCharQuantity: 53))))
            {
                textBoxQuaunity.ToolTip = "Это поле введено некорректно";
                textBoxQuaunity.Background = Brushes.Tomato;
                isAdding = false;
            }

            if(!(ValidationData.IsStringNotNull(comboBoxClient.Text.Trim())))
            {
                comboBoxClient.ToolTip = "Это поле введено некорректно";
                comboBoxClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxProduct.Text.Trim())))
            {
                comboBoxProduct.ToolTip = "Это поле введено некорректно";
                comboBoxProduct.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxStatus.Text.Trim())))
            {
                comboBoxStatus.ToolTip = "Это поле введено некорректно";
                comboBoxStatus.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (isAdding)
            {
                ProductInOrderModel productInOrderModel = new ProductInOrderModel()
                {
                    Articul = productInfoModel.Articul,
                    ProductId = productInfoModel.Id,
                    ProductTitle = productInfoModel.Title,
                    Price = productInfoModel.Price,
                    Quantity = Convert.ToInt32(quantity),
                    MeasureUnitId = productInfoModel.MeasureUnitId,
                    MeasureUnitTitle = productInfoModel.MeasureUnit,
                    GroupTitle = productInfoModel.Group,
                    SubgroupTitle = productInfoModel.Subgroup,
                    Rate = -1
                };

                _productInOrderModels.Add(productInOrderModel);

                totalPrice += productInOrderModel.Price * productInOrderModel.Quantity;
                textBoxTotalPrice.Text = totalPrice.ToString();

                gridProductsInOrder.Items.Add(productInOrderModel);
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfOrdersWindow());
        }

        private void comboBoxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string productTitle = comboBoxProduct.SelectedItem.ToString();

            int productId = (from p in _products
                             where p.ProductTitle.Equals(productTitle)
                             select p.ProductId)
                            .FirstOrDefault();

            productInfoModel = _controller.GetProductInfoModel(productId);

            labelMeasureUnit.Content = productInfoModel.MeasureUnit;
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
            string clientFullName = comboBoxClient.SelectedItem.ToString();

            int clientId = (from c in _clients
                            where c.FullName.Equals(clientFullName)
                            select c.Id)
                            .FirstOrDefault();

            string statusTitle = comboBoxStatus.SelectedItem.ToString();

            int statusId = (from c in _statuses
                            where c.Title.Equals(statusTitle)
                            select c.Id)
                            .FirstOrDefault();

            NewOrderInfoModel newOrderInfoModel = new NewOrderInfoModel()
            {
                ClientId = clientId,
                OrderDate = textBoxDate.Text,
                StatusesId = statusId,
                OrderReview = string.Empty,
                TotalPrice = totalPrice,
                ProductsInOrder = _productInOrderModels
            };

            _controller.AddOrder(newOrderInfoModel);

            NavigationService.Navigate(new ListOfOrdersWindow());
        }
    }
}
