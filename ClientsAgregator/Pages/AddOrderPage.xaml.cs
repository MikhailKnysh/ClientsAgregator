using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace ClientsAgregator.Pages
{
    public partial class AddOrderPage : Page
    {
        private List<ClientsFullNameModel> _clients;
        private List<StatusModel> _statuses;
        private List<ProductsSubgropModel> _products;
        private List<ProductInOrderModel> _productInOrderModels;
        private List<MeasureUnitInfoModel> _measureUnitInfoModels;
        private List<FeedbackModel> _feedbackModels;
        private ProductInfoModel productInfoModel;
        private double totalPrice;

        private Controller _controller;

        public AddOrderPage()
        {
            InitializeComponent();
        }

        private void AddOrderPage_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _productInOrderModels = new List<ProductInOrderModel>();
            _feedbackModels = new List<FeedbackModel>();

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

            _measureUnitInfoModels = _controller.GetMeasureUnit();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string quantity = textBoxQuaunity.Text.Trim();

            bool isAdding = true;

            if (!(ValidationData.IsNumber(quantity)
                || !(ValidationData.IsValidStringLenght(quantity, validCharQuantity: 53))))
            {
                textBoxQuaunity.ToolTip = "Введите цифры в формате ХХХ или ХХХ,ХХ";
                textBoxQuaunity.Background = Brushes.Tomato;
                isAdding = false;
            }

            if(!(ValidationData.IsStringNotNull(comboBoxClient.Text.Trim())))
            {
                comboBoxClient.ToolTip = "Необходимо выбрать один из вариантов в списке";
                comboBoxClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxProduct.Text.Trim())))
            {
                comboBoxProduct.ToolTip = "Необходимо выбрать один из вариантов в списке";
                comboBoxProduct.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxStatus.Text.Trim())))
            {
                comboBoxStatus.ToolTip = "Необходимо выбрать один из вариантов в списке";
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
                    Quantity = Convert.ToDouble(quantity),
                    MeasureUnitId = productInfoModel.MeasureUnitId,
                    MeasureUnitTitle = productInfoModel.MeasureUnit,
                    GroupTitle = productInfoModel.Group,
                    SubgroupTitle = productInfoModel.Subgroup,
                    Rate = -1
                };
                string measureUnitTitle = productInfoModel.MeasureUnit;

                int measureUnitId = (from m in _measureUnitInfoModels
                                     where m.Title.Equals(measureUnitTitle)
                                     select m.Id)
                                .FirstOrDefault();

                FeedbackModel newfeedbackModel = new FeedbackModel()
                {
                    ProductId = productInfoModel.Id,
                    Description = string.Empty,
                    Rate = -1
                };
                _productInOrderModels.Add(productInOrderModel);
                _feedbackModels.Add(newfeedbackModel);

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
                OrderDate = datePicker.Text,
                StatusesId = statusId,
                OrderReview = string.Empty,
                TotalPrice = totalPrice,
                ProductsInOrder = _productInOrderModels
            };

            foreach (FeedbackModel f in _feedbackModels)
            {
                f.ClientId = clientId;
                f.Date = datePicker.Text;
            }
            _controller.AddOrder(newOrderInfoModel);

            NavigationService.Navigate(new ListOfOrdersWindow());
        }
    }
}
