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
    /// <summary>
    /// Interaction logic for AgreeWindow.xaml
    /// </summary>
    public partial class AgreeWindow : Window
    {
        public AgreeWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*this.HorizontalAlignment = HorizontalAlignment.Center;

            this.VerticalAlignment = VerticalAlignment.Center;
            this.Top = Mouse.GetPosition(null).Y;

            this.Left = Mouse.GetPosition(null).X ;
        */
            
            this.Top = Mouse.GetPosition(null).Y ;
            this.Left = Mouse.GetPosition(null).X/2;
        }
    }
}
