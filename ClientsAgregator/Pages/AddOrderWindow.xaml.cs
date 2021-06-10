using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private List<ClientsFullNameModel> _clients;
        private List<StatusModel> _statuses;
        private List<ProductTitleModel> _products;
        private List<ProductInOrderModel> _productInOrderModels;

        private Controller _controller;

        public AddOrderWindow()
        {
            InitializeComponent();
            _controller = new Controller();
        }

        private void AddOrderWindow_Loaded(object sender, RoutedEventArgs e)
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

            _products = _controller.GetProductTitlesModels();
            foreach (var product in _products)
            {
                comboBoxProduct.Items.Add(product.Title);
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productTitle = comboBoxProduct.SelectedItem.ToString();

            int productId = (from p in _products
                             where p.Title.Equals(productTitle)
                             select p.Id)
                            .FirstOrDefault();

            ProductInfoModel productInfoModel = _controller.GetProductInfoModel(productId);

            ProductInOrderModel productInOrderModel = new ProductInOrderModel()
            {
                Articul = productInfoModel.Articul,
                ProductId = productInfoModel.Id,
                ProductTitle = productInfoModel.Title,
                Price = productInfoModel.Price,
                Quantity = Convert.ToInt32(textBoxQuaunity.Text),
                MeasureUnitTitle = productInfoModel.MeasureUnit,//null
                GroupTitle = productInfoModel.Group,//null
                SubgroupTitle = productInfoModel.Subgroup,//null
                Rate = -1
            };

            _productInOrderModels = new List<ProductInOrderModel>();
            _productInOrderModels.Add(productInOrderModel);

            gridProductsInOrder.ItemsSource = _productInOrderModels;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
