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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for UpdateClientPage.xaml
    /// </summary>
    public partial class UpdateClientPage : Page
    {
        private Controller _controller;
        private int _idClient;
        public UpdateClientPage(int idClient)
        {
            InitializeComponent();
            _idClient = idClient;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileClientWindow(_idClient));
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void buttonSave_Click(object sender, RoutedEventArgs e, int idClient)
        //{
        //    int _idClient = 4;

        //    AddClientModel clientModel = new AddClientModel()
        //    {
        //        LastName = TextBoxLastName.Text,
        //        FirstName = TextBoxFirstName.Text,
        //        MiddleName = TextBoxMiddleName.Text,
        //        Phone = TextBoxPhone.Text,
        //        Email = TextBoxEmail.Text,
        //        BulkStatusId = ComboBoxBulkStatus.SelectedIndex,
        //        Male = ComboBoxMale.Text,
        //        СommentAboutСlient = TextBoxCommentAboutClient.Text
        //    };

        //    _controller.UpdateClientDTO(clientModel, _idClient);
        //}

        //private void Page_Loaded(object sender, RoutedEventArgs e, int idClient)
        //{
        //    int _idClient = 4;
        //    _controller = new Controller();

        //    _controller.GetClientByIdModels(_idClient);

        //    List<BulkStatusModel> bulkStatusModel = _controller.GetBulkStatusesModels();

        //    foreach (var item in bulkStatusModel)
        //    {
        //        ComboBoxBulkStatus.Items.Add(item.Title);
        //    }


        //}

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

            List<BulkStatusModel> bulkStatusModel = _controller.GetBulkStatusesModels();

            foreach (var item in bulkStatusModel)
            {
                ComboBoxBulkStatus.Items.Add(item.Title);
            }
        }

        private void buttonSaveUptPage_Click(object sender, RoutedEventArgs e)
        {
            int _idClient = 4;

            AddClientModel clientModel = new AddClientModel()
            {
                LastName = TextBoxLastName.Text,
                FirstName = TextBoxFirstName.Text,
                MiddleName = TextBoxMiddleName.Text,
                Phone = TextBoxPhone.Text,
                Email = TextBoxEmail.Text,
                BulkStatusId = ComboBoxBulkStatus.SelectedIndex,
                Male = ComboBoxMale.Text,
                СommentAboutСlient = TextBoxCommentAboutClient.Text
            };

            _controller.UpdateClientDTO(clientModel, _idClient);
        }
    }
}
