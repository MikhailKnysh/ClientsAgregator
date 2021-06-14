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
                TextBoxLastName.ToolTip = "Поле не заполнено или превышено количество символов";
                TextBoxLastName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(firstName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(firstName)))
            {
                TextBoxFirstName.ToolTip = "Поле не заполнено или превышено количество символов";
                TextBoxFirstName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(middleName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(middleName)))
            {
                TextBoxMiddleName.ToolTip = "Поле не заполнено или превышено количество символов";
                TextBoxMiddleName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 800)))
            {
                TextBoxCommentAboutClient.ToolTip = "Превышено количество символов";
                TextBoxCommentAboutClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidPhone(phone))
                || !(ValidationData.IsValidStringLenght(phone, validCharQuantity: 60)))
            {
                TextBoxPhone.ToolTip = "Введите номер в формате +ХХХХХХХХХХХ(допустимое количество цифр в номере от 11 до 16)";
                TextBoxPhone.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidEmail(email))
                || !(ValidationData.IsValidStringLenght(email, validCharQuantity: 50)))
            {
                TextBoxEmail.ToolTip = "Это поле введено некорректно. Введите адрес в формате ААААА@ВВВВ.ССС";
                TextBoxEmail.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(male)))
            {
                ComboBoxMale.ToolTip = "Необходимо выбрать один из вариантов в списке";
                ComboBoxMale.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(bulkStatus)))
            {
                ComboBoxBulkStatus.ToolTip = "Необходимо выбрать один из вариантов в списке";
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

                NavigationService.Navigate(new ProfileClientWindow(_idClient, "ListOfClientsWindow"));
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileClientWindow(_idClient, "ListOfClientsWindow"));
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileClientWindow(_idClient, "ListOfClientsWindow"));
        }
    }
}
