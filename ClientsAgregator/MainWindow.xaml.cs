using ClientsAgregator.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
        }

        private void ListOfClientsPage_Click(object sender, RoutedEventArgs e)
        {
            ListOfClientsPage.Background = Brushes.Gray;
            ListOfProductsPage.Background = Brushes.LightGray;
            ListOfOrdersPage.Background = Brushes.LightGray;
            MainPage.Background = Brushes.LightGray;
            MainFrame.Navigate(new ListOfClientsWindow());
        }

        private void ListOfProductsPage_Click(object sender, RoutedEventArgs e)
        {
            ListOfProductsPage.Background = Brushes.Gray;
            ListOfClientsPage.Background = Brushes.LightGray;
            ListOfOrdersPage.Background = Brushes.LightGray;
            MainPage.Background = Brushes.LightGray;
            MainFrame.Navigate(new ListOfProductsPage());
        }

        private void ListOfOrdersPage_Click(object sender, RoutedEventArgs e)
        {
            ListOfOrdersPage.Background = Brushes.Gray;
            ListOfProductsPage.Background = Brushes.LightGray;
            ListOfClientsPage.Background = Brushes.LightGray;
            MainPage.Background = Brushes.LightGray;
            MainFrame.Navigate(new ListOfOrdersWindow());
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Background = Brushes.Gray;
            ListOfProductsPage.Background = Brushes.LightGray;
            ListOfClientsPage.Background = Brushes.LightGray;
            ListOfOrdersPage.Background = Brushes.LightGray;
            MainFrame.Navigate(new MainPage());
        }
    }
}
