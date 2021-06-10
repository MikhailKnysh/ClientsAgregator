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
using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;



namespace ClientsAgregator.Pages
{
    /// <summary>
    /// Interaction logic for AddClientPage.xaml
    /// </summary>
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
            AddClientModel addClientModel = new AddClientModel()
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

            _controller.AddClientDTO(addClientModel);

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
