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
using System.Windows.Shapes;

namespace ClientsAgregator
{
    public partial class AddProductReview : Window
    {
        public string ProductReview { get; private set; }

        public AddProductReview()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {
            ProductReview = textBoxProductReview.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
