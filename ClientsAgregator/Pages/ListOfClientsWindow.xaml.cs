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
        Controller controller = new Controller();

        List<ClientModel> clientModel;
        public ListOfClientsWindow()
        {
            InitializeComponent();
            clientModel = controller.GetClientsModels();

            for (int i = 0; i < clientModel.Count; i++)
            {
                clientsGrid.Items.Add(clientModel[i]);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var index = clientsGrid.SelectedIndex;
            clientsGrid.Items.RemoveAt(index);
        }

        private void ediBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileClientWindow profileClientPage = new ProfileClientWindow(clientModel[clientsGrid.SelectedIndex].Id);
            NavigationService.Navigate(profileClientPage);
        }

        private void AddingClientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage());
        }
    }
}
