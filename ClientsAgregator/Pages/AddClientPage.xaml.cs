using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;

namespace ClientsAgregator.Pages
{
    public partial class AddClientPage : Page
    {
        private Controller _controller;

        public AddClientPage()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfClientsWindow());
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();

            string email = TextBoxEmail.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();

            bool isValidEmail = ValidationData.IsValidEmail(email);
            bool isValidPhone = ValidationData.IsValidPhone(phone);
            bool isValidString = ValidationData.IsValidStringLenght(lastName, 255);

            if(isValidString == false)
            {
                TextBoxLastName.ToolTip = "Это поле введено некорректно";
                TextBoxLastName.Background = Brushes.Tomato;
            }
            else if (isValidPhone == false)
            {
                TextBoxPhone.Background = Brushes.Tomato;
            }
            else if (isValidEmail == false)
            {
                TextBoxPhone.Background = Brushes.Transparent;
                TextBoxEmail.Background = Brushes.Tomato;
            }
            else
            {
                TextBoxLastName.Background = Brushes.Transparent;
                TextBoxEmail.Background = Brushes.Transparent;

                AddClientModel addClientModel = new AddClientModel()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Phone = phone,
                    Email = email,
                    BulkStatusId = ComboBoxBulkStatus.SelectedIndex,
                    Male = ComboBoxMale.Text,
                    СommentAboutСlient = TextBoxCommentAboutClient.Text
                };

                _controller.AddClientDTO(addClientModel);

                MessageBox.Show("Клиент добавлен");

                //foreach (UIElement element in AddClientRoot.Children)
                //{
                //    if (element.GetType() == typeof(TextBox) || element.GetType() == typeof(CheckBox))
                //    {
                //        element.Text = string.Empty;
                //    }
                //}

                TextBoxLastName.Clear();
                TextBoxFirstName.Clear();
                TextBoxMiddleName.Clear();
                TextBoxPhone.Clear();
                TextBoxEmail.Clear();
                TextBoxCommentAboutClient.Clear();
                ComboBoxBulkStatus.Text = "";
                ComboBoxMale.Text = "";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            List<BulkStatusModel> bulkStatusModel = _controller.GetBulkStatusesModels();

            foreach (var item in bulkStatusModel)
            {
                ComboBoxBulkStatus.Items.Add(item.Title);
            }
        }
    }
}
