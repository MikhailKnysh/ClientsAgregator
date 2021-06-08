using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for ListOfProductsWindow.xaml
    /// </summary>
    public partial class ListOfProductsWindow : Window
    {
        private Controller _controller;
        List<ProductInfoModel> _productInfoModels; 
        
        public ListOfProductsWindow()
        {
            InitializeComponent();
        }

  
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            AgreeWindow agree = new AgreeWindow();
            if (agree.ShowDialog() == true)
            {
                var index = ProductsGrid.SelectedIndex;
                _controller.DeleteProduct(_productInfoModels[index].Id);
                ProductsGrid.Items.RemoveAt(index);
                _productInfoModels.RemoveAt(index);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _productInfoModels = _controller.GetProductInfoModels();
            foreach (var item in _productInfoModels)
            {
                ProductsGrid.Items.Add(item);
            }
            //ProductsGrid.ItemsSource = _productInfoModels;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddingOfProductWindow addingOfProductWindow = new AddingOfProductWindow();
            addingOfProductWindow.Show();
            this.Close();
        }
    }
}
