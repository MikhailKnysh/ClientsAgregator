﻿using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for ProfileClientWindow.xaml
    /// </summary>
    public partial class ProfileClientWindow : Page
    {


        private Controller _controller = new Controller();
        private ClientModel _clientModel;
        private List<ProductBuyClientModel> _productsBuyClientModel;
        private int _idClient;

        public ProfileClientWindow(int IdClient)
        {
            InitializeComponent();
            _idClient = IdClient;

            _clientModel = _controller.GetClientByIdModels(_idClient);

            lastNameLabel.Content = _clientModel.LastName;
            firstNameAndMiddleNameLabel.Content = _clientModel.FirstName + " " +  _clientModel.MiddleName;
            emailLabel.Content = _clientModel.Email;
            phoneLabel.Content = _clientModel.Phone;
            bulkstatusLabel.Content = _clientModel.BulkStatusTitle;
            MaleLabel.Content = _clientModel.Male;

            _productsBuyClientModel = _controller.GetProductsBuyClientModels(_idClient);

            for (int i = 0; i < _productsBuyClientModel.Count; i++)
            {
                clientsGrid.Items.Add(_productsBuyClientModel[i]);
            }
        }

        private void ButtonBackListOfclientsPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfClientsWindow());
        }

        private void ButtonOpenUpdateClientPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateClientPage(_idClient));
        }
    }
}
