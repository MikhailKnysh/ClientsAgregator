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
        private List<BulkStatusModel> _bulkStatusModel = new List<BulkStatusModel>();

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
            int bulkStatusIndex = ComboBoxBulkStatus.SelectedIndex;
            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();
            string commentAboutСlient = TextBoxCommentAboutClient.Text.Trim();
            string email = TextBoxEmail.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();

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
                AddClientModel addClientModel = new AddClientModel()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Phone = phone,
                    Email = email,
                    BulkStatusId = _bulkStatusModel[bulkStatusIndex].Id,
                    Male = ComboBoxMale.Text,
                    СommentAboutСlient = TextBoxCommentAboutClient.Text
                };

                _controller.AddClientDTO(addClientModel);

                MessageBox.Show("Клиент добавлен");

                foreach (UIElement element in AddClientGrid.Children)
                {
                    if (element is TextBox)
                    {
                        TextBox textBox = (TextBox)element;
                        textBox.Background = Brushes.Transparent;
                        textBox.Clear();
                    }

                    if (element is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)element;
                        comboBox.Background = Brushes.Transparent;
                        comboBox.Text = string.Empty;
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _controller = new Controller();
            _bulkStatusModel = _controller.GetBulkStatusesModels();

            foreach (var item in _bulkStatusModel)
            {
                ComboBoxBulkStatus.Items.Add(item.Title);
            }
        }
    }
}
