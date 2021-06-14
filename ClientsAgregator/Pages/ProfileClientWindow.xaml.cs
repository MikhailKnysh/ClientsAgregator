using ClientsAgregator.Pages;
using ClientsAgregator_BLL;
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
        private string _prevPage;
        private Controller _controller = new Controller();
        private ProductsBuyClientAndFeedback _productsBuyClientAndFeedback = new ProductsBuyClientAndFeedback();

        private ClientModel _clientModel;

        private List<ProductBuyClientModel> _productsBuyClientModels;
        private int _idClient;

        public ProfileClientWindow(int IdClient, string prevPage)
        {
            InitializeComponent();
            _idClient = IdClient;
            _prevPage = prevPage;
        }

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
            switch (_prevPage)
            {
                case "mainPage":
                    NavigationService.Navigate(new MainPage());
                    break;
                case "ListOfClientsWindow":
                    NavigationService.Navigate(new ListOfClientsWindow());
                    break;
            }
        }

        private void ButtonOpenUpdateClientPage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateClientPage(_idClient));
        }
    }
}
