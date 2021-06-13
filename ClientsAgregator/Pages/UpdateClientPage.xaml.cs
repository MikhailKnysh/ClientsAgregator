using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for UpdateClientPage.xaml
    /// </summary>
    public partial class UpdateClientPage : Page
    {
        private Controller _controller;
        private List<BulkStatusModel> _bulkStatusModel = new List<BulkStatusModel>();
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
            int index1 = ComboBoxBulkStatus.SelectedIndex;
            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();
            string email = TextBoxEmail.Text.Trim();
            string commentAboutСlient = TextBoxCommentAboutClient.Text.Trim();
            string male = ComboBoxMale.Text.Trim();
            string bulkStatus = ComboBoxBulkStatus.Text.Trim();

            bool isAdding = true;

            foreach (UIElement item in UpdateClientRoot.Children)
            {
                lastName = TextBoxLastName.Text;
                firstName = TextBoxFirstName.Text;
                middleName = TextBoxMiddleName.Text;
                phone = TextBoxPhone.Text;
                email = TextBoxEmail.Text;
             //   bulkStatus = _bulkStatusModel[index1].Id;
                male = ComboBoxMale.Text;
                commentAboutСlient = TextBoxCommentAboutClient.Text;
            };

            if (!(ValidationData.IsValidStringLenght(lastName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(lastName)))
            {
                TextBoxLastName.ToolTip = "Это поле введено некорректно";
                TextBoxLastName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(firstName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(firstName)))
            {
                TextBoxFirstName.ToolTip = "Это поле введено некорректно";
                TextBoxFirstName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(middleName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(middleName)))
            {
                TextBoxMiddleName.ToolTip = "Это поле введено некорректно";
                TextBoxMiddleName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 800)))
            {
                TextBoxCommentAboutClient.ToolTip = "Это поле введено некорректно";
                TextBoxCommentAboutClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidPhone(phone)) || !(ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 60)))
            {
                TextBoxPhone.ToolTip = "Это поле введено некорректно. Обязательно введите первым символ + и потом цифры номера";
                TextBoxPhone.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidEmail(email)) || !(ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 50)))
            {
                TextBoxEmail.ToolTip = "Это поле введено некорректно";
                TextBoxEmail.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(male))
                || !(ValidationData.IsStringNotNull(male)))
            {
                ComboBoxMale.ToolTip = "Это поле введено некорректно";
                ComboBoxMale.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(bulkStatus))
                || !(ValidationData.IsStringNotNull(bulkStatus)))
            {
                ComboBoxBulkStatus.ToolTip = "Это поле введено некорректно";
                ComboBoxBulkStatus.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (isAdding)
            {
                var index = ComboBoxBulkStatus.SelectedIndex;

                AddClientModel clientModel = new AddClientModel()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Phone = phone,
                    Email = email,
                    BulkStatusId = _bulkStatusModel[index].Id,
                    Male = ComboBoxMale.Text,
                    CommentAboutClient = commentAboutСlient
                };

                _controller.UpdateClientDTO(clientModel, _idClient);

                MessageBox.Show("Информация о клиенте изменена");

                NavigationService.Navigate(new ListOfClientsWindow());
            }
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
