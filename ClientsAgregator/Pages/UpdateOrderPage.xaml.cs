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
        private List<FeedbackModel> _feedbackModels;

        public UpdateOrderPage(OrdersInfoModel ordersInfoModel)
        {
            InitializeComponent();

            _ordersInfoModel = ordersInfoModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _productInOrderModels = _controller.GetProductsInOrderByOrderId(_ordersInfoModel.Id);
            _feedbackModels = new List<FeedbackModel>();
            foreach (ProductInOrderModel p in _productInOrderModels)
            {
                _feedbackModels.Add(new FeedbackModel() { ProductId = p.ProductId, OrderId = _ordersInfoModel.Id, Rate = p.Rate, Description = p.ProductReview});
            }

            labelPageTitle.Content += _ordersInfoModel.Id.ToString();

            _clients = _controller.GetClientsFullNameModels();
            foreach (var client in _clients)
            {
                comboBoxClient.Items.Add(client.FullName);
            }

            string fullName = $"{_ordersInfoModel.LastName} {_ordersInfoModel.FirstName} {_ordersInfoModel.MiddleName}";
            comboBoxClient.SelectedItem = fullName;

            datePicker.Text = _ordersInfoModel.OrderDate;

            _statuses = _controller.GetStatusModels();
            foreach (var status in _statuses)
            {
                comboBoxStatus.Items.Add(status.Title);
            }

            _orderModel = _controller.GetOrdersInfoById(_ordersInfoModel.Id);
            StatusModel statusModel = (from s in _statuses
                                       where s.Id == _orderModel.StatusesId
                                       select s).FirstOrDefault();

            comboBoxStatus.SelectedItem = statusModel.Title;

            _products = _controller.GetProductsSubgroupModels();
            foreach (var product in _products)
            {
                comboBoxProduct.Items.Add(product.ProductTitle);
            }

            gridProductsInOrder.ItemsSource = _productInOrderModels;

            textBoxOrderReview.Text = _ordersInfoModel.OrderReview;
            totalPrice = _ordersInfoModel.TotalPrice;
            textBoxTotalPrice.Text = totalPrice.ToString();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfOrdersWindow());
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string quantity = textBoxQuaunity.Text.Trim();
            string rate = comboBoxRate.Text.Trim();

            bool isAdding = true;

            if(rate is null)
            {
                rate = "-1";
            }

            if (!(ValidationData.IsNumber(quantity)
               || !(ValidationData.IsValidStringLenght(quantity, validCharQuantity: 53))))
            {
                textBoxQuaunity.ToolTip = "Это поле введено некорректно. Введите цифры в формате ХХХ или ХХХ.ХХ";
                textBoxQuaunity.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxClient.Text.Trim())))
            {
                comboBoxClient.ToolTip = "Это поле введено некорректно. Необходимо выбрать один из вариантов в списке";
                comboBoxClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxProduct.Text.Trim())))
            {
                comboBoxProduct.ToolTip = "Это поле введено некорректно. Необходимо выбрать один из вариантов в списке";
                comboBoxProduct.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(comboBoxStatus.Text.Trim())))
            {
                comboBoxStatus.ToolTip = "Это поле введено некорректно. Необходимо выбрать один из вариантов в списке";
                comboBoxStatus.Background = Brushes.Tomato;
                isAdding = false;
            }

            if(ValidationData.IsValidStringLenght(textBoxOrderReview.Text.Trim(), 800))
            {
                textBoxOrderReview.ToolTip = "Это поле введено некорректно. Превышено количество введенных символов";
                textBoxOrderReview.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (isAdding)
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
                    Rate = Convert.ToInt32(rate)
                };
                FeedbackModel newfeedbackModel = new FeedbackModel()
                {
                    ProductId = _productInfoModel.Id,
                    Description = string.Empty,
                    Rate = -1
                };

                _productInOrderModels.Add(productInOrderModel);

                totalPrice += productInOrderModel.Price * productInOrderModel.Quantity;
                textBoxTotalPrice.Text = totalPrice.ToString();

                gridProductsInOrder.ItemsSource = _productInOrderModels;
                gridProductsInOrder.Items.Refresh();
            }
        }

        private void comboBoxRateInGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string result = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            _productInOrderModels[gridProductsInOrder.SelectedIndex].Rate = Convert.ToInt32(result);
            _feedbackModels[gridProductsInOrder.SelectedIndex].Rate = Convert.ToInt32(result);
            
            gridProductsInOrder.Items.Refresh();

        }
        private void comboBoxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string productTitle = comboBoxProduct.SelectedItem.ToString();

            int productId = (from p in _products
                             where p.ProductTitle.Equals(productTitle)
                             select p.ProductId)
                            .FirstOrDefault();

            _productInfoModel = _controller.GetProductInfoModel(productId);

            labelMeasureUnit.Content = _productInfoModel.MeasureUnit;
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            AgreeWindow agreeWindow = new AgreeWindow();

            if (agreeWindow.ShowDialog() == true)
            {
                int index = gridProductsInOrder.SelectedIndex;

                totalPrice -= _productInOrderModels[index].Price * _productInOrderModels[index].Quantity;
                textBoxTotalPrice.Text = totalPrice.ToString();

                _productInOrderModels.RemoveAt(index);
                gridProductsInOrder.ItemsSource = _productInOrderModels;
                gridProductsInOrder.Items.Refresh();
            }
        }

        private void buttonAddReview_Click(object sender, RoutedEventArgs e)
        {
            AddProductReview addProductReview = new AddProductReview(_feedbackModels[gridProductsInOrder.SelectedIndex].Description);
            addProductReview.ShowDialog();

            _feedbackModels[gridProductsInOrder.SelectedIndex].Description = addProductReview.ProductReview;
            _productInOrderModels[gridProductsInOrder.SelectedIndex].ProductReview = addProductReview.ProductReview;
            gridProductsInOrder.ItemsSource = _productInOrderModels;
            gridProductsInOrder.Items.Refresh();
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

            NewOrderInfoModel updatedOrderInfoModel = new NewOrderInfoModel()
            {
                ClientId = clientId,
                OrderDate = datePicker.Text,
                StatusesId = statusId,
                OrderReview = textBoxOrderReview.Text,
                TotalPrice = totalPrice,
                ProductsInOrder = _productInOrderModels
            };

            foreach (FeedbackModel f in _feedbackModels)
            {
                f.ClientId = clientId;
                f.Date = datePicker.Text;
            }

            _controller.UpdateOrder(updatedOrderInfoModel, _ordersInfoModel.Id, _feedbackModels);

            NavigationService.Navigate(new ListOfOrdersWindow());
        }
    }
}
