using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientsAgregator.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Controller _controller;
        List<ProductsSubgropModel> productsSubgropModels ;
        List<InterestedClientInfoByProductModel> interestedClientInfoByProductModels;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            interestedClientInfoByProductModels = new List<InterestedClientInfoByProductModel>();
            _controller = new Controller();
            productsSubgropModels = _controller.GetProductsSubgroupModels();
            foreach (var productsSubgrop in productsSubgropModels)
            {
               ProductsSubgroupComboBox.Items.Add(productsSubgrop.ProductTitle);
            }
        }

        private void ProductsSubgroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                    
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            InterestedClientByProductGrid.Items.Clear();
            int productId = productsSubgropModels[ProductsSubgroupComboBox.SelectedIndex].ProductId;
            interestedClientInfoByProductModels = _controller.GetMainModels(productId);
            foreach (var intrClient in interestedClientInfoByProductModels)
            {
                InterestedClientByProductGrid.Items.Add(intrClient);
            }
        }
    }
}
