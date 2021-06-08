﻿using System;
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
            MainFrame.Content = MainPage;
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListOfClientsPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ListOfClientsPage);
        }

        private void ListOfProductsPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ListOfProductsPage);
        }

        private void ListOfOrdersPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ListOfOrdersPage);
        }
    }
}
