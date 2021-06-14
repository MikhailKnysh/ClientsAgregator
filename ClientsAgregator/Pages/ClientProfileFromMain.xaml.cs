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

namespace ClientsAgregator.Pages
{
    /// <summary>
    /// Interaction logic for ClientProfileFromMain.xaml
    /// </summary>
    public partial class ClientProfileFromMain : Window
    {
        public ClientProfileFromMain(int IdClient)
        {
            InitializeComponent();
            _idClient = IdClient;
        }
        private Controller _controller = new Controller();
        private ProductsBuyClientAndFeedback _productsBuyClientAndFeedback = new ProductsBuyClientAndFeedback();

        private ClientModel _clientModel;

        private List<ProductBuyClientModel> _productsBuyClientModels;
        private int _idClient;

        private void ProfileClient_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _clientModel = _controller.GetClientByIdModels(_idClient);

            lastNameLabel.Content = _clientModel.LastName;
            firstNameAndMiddleNameLabel.Content = _clientModel.FirstName + " " + _clientModel.MiddleName;
            emailLabel.Content = _clientModel.Email;
            phoneLabel.Content = _clientModel.Phone;
            bulkstatusLabel.Content = _clientModel.BulkStatusTitle;
            MaleLabel.Content = _clientModel.Male;
            TextBoxCommentAboutClient.Text = _clientModel.СommentAboutСlient;

            _productsBuyClientModels = _productsBuyClientAndFeedback.GetProductBuyClientAndFeedback(_idClient);

            if (_productsBuyClientModels.Count != 0)
            {
                totalPriceLabel.Content = _controller.GetSpendMoneyCountByClientIdModels(_idClient);

            }
            else
            {
                totalPriceLabel.Content = "0";
            }

            for (int i = 0; i < _productsBuyClientModels.Count; i++)
            {
                clientsGrid.Items.Add(_productsBuyClientModels[i]);
            }
        }

        private void ButtonBackListOfclientsPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonOpenUpdateClientPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
