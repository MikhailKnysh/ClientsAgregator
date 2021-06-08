using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
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
using System.Windows.Shapes;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for AddingSubgroup.xaml
    /// </summary>
    public partial class AddingSubgroup : Window
    {
        private Controller _controller;
        List<GroupInfoModel> groupModels;

        public AddingSubgroup()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            _controller.AddSubgropGroup(groupModels[GroupComboBox.SelectedIndex].Id, SubgroupTextBox.Text);

            this.DialogResult = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AcceptButton.IsEnabled = false;
            _controller = new Controller();
            groupModels = _controller.GetGroups();

            foreach (var group in groupModels)
            {
                GroupComboBox.Items.Add(group.Title);
            }
        }

        private void GroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AcceptButton.IsEnabled = true;
        }
    }
}
