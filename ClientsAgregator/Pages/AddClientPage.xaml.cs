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
            string lastName = TextBoxLastName.Text.Trim();
            string firstName = TextBoxFirstName.Text.Trim();
            string middleName = TextBoxMiddleName.Text.Trim();
            string commentAboutСlient = TextBoxCommentAboutClient.Text.Trim();
            string email = TextBoxEmail.Text.Trim();
            string phone = TextBoxPhone.Text.Trim();
            string male = ComboBoxMale.Text.Trim();
            string bulkStatus = ComboBoxBulkStatus.Text.Trim();

            bool isAdding = true;

            foreach (UIElement item in AddClientRoot.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Background = Brushes.Transparent;
                }
            }

            if (!(ValidationData.IsValidStringLenght(lastName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(lastName)))
            {
                TextBoxLastName.ToolTip = "Это поле введено некорректно. Поле не заполнено или превышено количество символов";
                TextBoxLastName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(firstName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(firstName)))
            {
                TextBoxFirstName.ToolTip = "Это поле введено некорректно. Поле не заполнено или превышено количество символов";
                TextBoxFirstName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(middleName, validCharQuantity: 255))
                || !(ValidationData.IsStringNotNull(middleName)))
            {
                TextBoxMiddleName.ToolTip = "Это поле введено некорректно. Поле не заполнено или превышено количество символов";
                TextBoxMiddleName.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(commentAboutСlient, validCharQuantity: 800)))
            {
                TextBoxCommentAboutClient.ToolTip = "Это поле введено некорректно. Поле не заполнено или превышено количество символов";
                TextBoxCommentAboutClient.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidPhone(phone)) || !(ValidationData.IsValidStringLenght(phone, validCharQuantity: 60)))
            {
                TextBoxPhone.ToolTip = "Это поле введено некорректно. Введите номер в формате +ХХХХХХХХХХХ(допустимое количество цифр в номере от 11 до 16)";
                TextBoxPhone.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidEmail(email)) || !(ValidationData.IsValidStringLenght(email, validCharQuantity: 50)))
            {
                TextBoxEmail.ToolTip = "Это поле введено некорректно. Введите адрес в формате ААААА@ВВВВ.ССС";
                TextBoxEmail.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(male))
                || !(ValidationData.IsStringNotNull(male)))
            {
                ComboBoxMale.ToolTip = "Это поле введено некорректно. Необходимо выбрать один из вариантов в списке";
                ComboBoxMale.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(bulkStatus))
                || !(ValidationData.IsStringNotNull(bulkStatus)))
            {
                ComboBoxBulkStatus.ToolTip = "Это поле введено некорректно. Необходимо выбрать один из вариантов в списке";
                ComboBoxBulkStatus.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (isAdding)
            {
                int bulkStatusIndex = ComboBoxBulkStatus.SelectedIndex;

                AddClientModel addClientModel = new AddClientModel()
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    Phone = phone,
                    Email = email,
                    BulkStatusId = _bulkStatusModel[bulkStatusIndex].Id,
                    Male = male,
                    CommentAboutClient = commentAboutСlient
                };

                _controller.AddClientDTO(addClientModel);

                foreach (UIElement element in AddClientRoot.Children)
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
                        comboBox.Text = string.Empty;
                    }
                }

                MessageBox.Show("Клиент успешно добавлен");
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
