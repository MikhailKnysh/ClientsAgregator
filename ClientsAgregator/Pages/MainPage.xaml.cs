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
        List<ProductsSubgropModel> productsSubgropModels;
        List<InterestedClientInfoByProductModel> interestedClientInfoByProductModels;
        List<InterestedClientInfoByProductModel> interestedClientInfoBySubgroupModels;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateButton.IsEnabled = false;
            interestedClientInfoBySubgroupModels = new List<InterestedClientInfoByProductModel>();
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
            CreateButton.IsEnabled = true;
            SubgroupLabel.Content = $"Подгруппа: {productsSubgropModels[ProductsSubgroupComboBox.SelectedIndex].SubgroupTitle}";
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
                InterestedClientBySubgroupGrid.Items.Clear();
                InterestedClientByProductGrid.Items.Clear();
                int subgroupId = productsSubgropModels[ProductsSubgroupComboBox.SelectedIndex].SubgroupId;
                int productId = productsSubgropModels[ProductsSubgroupComboBox.SelectedIndex].ProductId;
                interestedClientInfoBySubgroupModels = _controller.GetInterestedClientInfoBySubgroup(subgroupId);
                interestedClientInfoByProductModels = _controller.GetInterestedClientInfoByProduct(productId);

                foreach (var intrClient in interestedClientInfoByProductModels)
                {
                    InterestedClientByProductGrid.Items.Add(intrClient);
                }

                foreach (var intrClient in interestedClientInfoBySubgroupModels)
                {
                    InterestedClientBySubgroupGrid.Items.Add(intrClient);
                }
        }

        private void ClientByProductButton_Click(object sender, RoutedEventArgs e)
        {
            int intrestedClientIndex = InterestedClientByProductGrid.SelectedIndex;
            int intrestedClientId = interestedClientInfoByProductModels[intrestedClientIndex].ClientId;
            //NavigationService.Navigate(new ProfileClientWindow(intrestedClientId));
            ClientProfileFromMain pcw = new ClientProfileFromMain(intrestedClientId);
            pcw.ShowDialog();
        }
        private void ClientBySubgroupButton_Click(object sender, RoutedEventArgs e)
        {
            int intrestedClientIndex = InterestedClientBySubgroupGrid.SelectedIndex;
            int intrestedClientId = interestedClientInfoBySubgroupModels[intrestedClientIndex].ClientId;
            //NavigationService.Navigate(new ProfileClientWindow(intrestedClientId));
            ClientProfileFromMain pcw = new ClientProfileFromMain(intrestedClientId);
            pcw.ShowDialog();
        }
    }
}
