﻿using ClientsAgregator_BLL;
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
            var index = ComboBoxBulkStatus.SelectedIndex;

            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();
            string email = TextBoxEmail.Text.Trim();
            string commentAboutСlient = TextBoxCommentAboutClient.Text.Trim();

            bool isValidEmail = ValidationData.IsValidEmail(email);
            bool isValidPhone = ValidationData.IsValidPhone(phone);
            bool isValidStringLastName = ValidationData.IsValidStringLenght(lastName, validCharQuantity: 255);
            bool isValidStringFirstName = ValidationData.IsValidStringLenght(firstName, validCharQuantity: 255);
            bool isValidStringMiddleName = ValidationData.IsValidStringLenght(middleName, validCharQuantity: 255);
            bool isValidStringcomment = ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 800);
            bool isValidStringEmail = ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 50);
            bool isValidStringPhone = ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 60);

            if (isValidStringLastName == false)
            {
                TextBoxLastName.ToolTip = "Это поле введено некорректно";
                TextBoxLastName.Background = Brushes.Tomato;
            }
            else if (isValidStringFirstName == false)
            {
                TextBoxFirstName.ToolTip = "Это поле введено некорректно";
                TextBoxFirstName.Background = Brushes.Tomato;
            }
            else if (isValidStringMiddleName == false)
            {
                TextBoxMiddleName.ToolTip = "Это поле введено некорректно";
                TextBoxMiddleName.Background = Brushes.Tomato;
            }
            else if (isValidStringcomment == false)
            {
                TextBoxCommentAboutClient.ToolTip = "Это поле введено некорректно";
                TextBoxCommentAboutClient.Background = Brushes.Tomato;
            }
            else if (isValidPhone == false || isValidStringPhone == false)
            {
                TextBoxPhone.ToolTip = "Это поле введено некорректно";
                TextBoxPhone.Background = Brushes.Tomato;
            }
            else if (isValidEmail == false || isValidStringEmail == false)
            {
                TextBoxEmail.ToolTip = "Это поле введено некорректно";
                TextBoxPhone.Background = Brushes.Transparent;
                TextBoxEmail.Background = Brushes.Tomato;
            }
            else
            {
                AddClientModel clientModel = new AddClientModel()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Phone = phone,
                    Email = email,
                    BulkStatusId = _bulkStatusModel[index].Id,
                    Male = ComboBoxMale.Text,
                    СommentAboutСlient = commentAboutСlient
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
