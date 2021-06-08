using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for ListOfProductsPage.xaml
    /// </summary>
    public partial class ListOfProductsPage : Page
    {
        private Controller _controller;
        List<ProductInfoModel> _productInfoModels;

        public ListOfProductsPage()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddingOfProductWindow addingOfProductWindow = new AddingOfProductWindow();
            addingOfProductWindow.Show();
           // this.Close();
        }
    }
}
