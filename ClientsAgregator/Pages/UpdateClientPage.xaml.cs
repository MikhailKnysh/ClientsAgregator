using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for UpdateClientPage.xaml
    /// </summary>
    public partial class UpdateClientPage : Page
    {
        private Controller _controller;        private List<BulkStatusModel> _bulkStatusModel = new List<BulkStatusModel>();
        private int _idClient;

        public UpdateClientPage(int idClient)
        {
            InitializeComponent();
            _idClient = idClient;
        }

        private void UpdatePage_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();

            ClientModel client = _controller.GetClientByIdModels(_idClient);

            TextBoxLastName.Text = client.LastName;
            TextBoxFirstName.Text = client.FirstName;
            TextBoxMiddleName.Text = client.MiddleName;
            TextBoxPhone.Text = client.Phone;
            TextBoxEmail.Text = client.Email;
            ComboBoxBulkStatus.SelectedItem = client.BulkStatusTitle;
            ComboBoxMale.Text = client.Male;
            TextBoxCommentAboutClient.Text = client.СommentAboutСlient;

            _bulkStatusModel = _controller.GetBulkStatusesModels();

            foreach (var item in _bulkStatusModel)
            {
                ComboBoxBulkStatus.Items.Add(item.Title);
            }
        }

        private void buttonSaveUptPage_Click(object sender, RoutedEventArgs e)
        {
            var index = ComboBoxBulkStatus.SelectedIndex;

            AddClientModel clientModel = new AddClientModel()
            {
                LastName = TextBoxLastName.Text,
                FirstName = TextBoxFirstName.Text,
                MiddleName = TextBoxMiddleName.Text,
                Phone = TextBoxPhone.Text,
                Email = TextBoxEmail.Text,
                BulkStatusId = _bulkStatusModel[index].Id,
                Male = ComboBoxMale.Text,
                СommentAboutСlient = TextBoxCommentAboutClient.Text
            };

            _controller.UpdateClientDTO(clientModel, _idClient);

            NavigationService.Navigate(new ListOfClientsWindow());
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfClientsWindow());
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfClientsWindow());
        }
    }
}
