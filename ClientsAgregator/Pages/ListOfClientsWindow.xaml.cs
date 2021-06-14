using ClientsAgregator.Pages;
using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for ListOfClientsWindow.xaml
    /// </summary>
    public partial class ListOfClientsWindow : Page
    {
        const string listOfClientPage = "ListOfClientsWindow";
        private Controller _controller = new Controller();
        private List<ClientModel> _clientModel;

        public ListOfClientsWindow()
        {
            InitializeComponent();
            _clientModel = _controller.GetClientsModels();

            for (int i = 0; i < _clientModel.Count; i++)
            {
                clientsGrid.Items.Add(_clientModel[i]);
            }
        }

        private void buttonDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            AgreeWindow agree = new AgreeWindow();
            if (agree.ShowDialog() == true)
            {
                var index = clientsGrid.SelectedIndex;
                clientsGrid.Items.RemoveAt(index);
            }
        }

        private void buttonOpenAddClientPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }

        private void buttonOpenProfileClientPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileClientWindow(_clientModel[clientsGrid.SelectedIndex].Id,listOfClientPage));
        }
    }
}
