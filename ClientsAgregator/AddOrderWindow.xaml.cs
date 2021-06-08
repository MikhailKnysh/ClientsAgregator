using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
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
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private Controller _controller;

        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            List<BulkStatusModel> bulkStatusModel = _controller.GetBulkStatusesModels();

            foreach (var item in bulkStatusModel)
            {
                ComboBoxBulkStatus.Items.Add(item.Title);
            }
        }
    }
}
