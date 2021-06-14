using ClientsAgregator_BLL;
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

        public AddProductReview(string productReview)
        {
            InitializeComponent();
            ProductReview = productReview;
            textBoxProductReview.Text = ProductReview;
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {

            if (ValidationData.IsValidStringLenght(ProductReview, validCharQuantity: 8000))
            {
                ProductReview = textBoxProductReview.Text.Trim();
                this.Close();
            }
            else
            {
                textBoxProductReview.Background = Brushes.Tomato;
                textBoxProductReview.ToolTip = "Превышено количество символов";
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
