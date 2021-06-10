using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels.ProductsModel;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for AddingOfProductPage.xaml
    /// </summary>
    public partial class AddingOfProductPage : Page
    {
        List<SubgroupInfoModel> subgroupInfoModels;
        List<MeasureUnitInfoModel> measureUnitInfoModels;
        private Controller _controller;

        public AddingOfProductPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListOfProductsPage());
        }

        private void AddingProductWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SubgroupComboBox.IsEnabled = false;
            _controller = new Controller();
            List<GroupInfoModel> groupModels = _controller.GetGroups();

            foreach (var group in groupModels)
            {
                GroupComboBox.Items.Add(group.Title);
            }

            measureUnitInfoModels = _controller.GetMeasureUnit();
            foreach (var unit in measureUnitInfoModels)
            {
                MeasureUnitComboBox.Items.Add(unit.Title);
            }
        }

        private void GroupComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SubgroupComboBox.IsEnabled = true;
            SubgroupComboBox.Items.Clear();

            int groupID = GroupComboBox.SelectedIndex;
            
            ++groupID;

            subgroupInfoModels = _controller.GetSubgroupsInfoByGroupId(groupID);

            foreach (var subgroup in subgroupInfoModels)
            {
                SubgroupComboBox.Items.Add(subgroup.Title);
            }
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            MeasureUnitInfoModel measureUnitModel = measureUnitInfoModels[MeasureUnitComboBox.SelectedIndex];
            SubgroupInfoModel subgroupModel = subgroupInfoModels[SubgroupComboBox.SelectedIndex];

            AddingProductModel addingProductModel = new AddingProductModel()
            {
                Articul = ArticulTextBox.Text,
                Title = TitelTextBox.Text,
                Quantity = Convert.ToInt32(QuantityTextBox.Text),
                Price = Convert.ToDouble(PriceTextBox.Text),
                MeasureId = measureUnitModel.Id,
                SubgroupId = subgroupModel.Id
            };

            _controller.AddProduct(addingProductModel);
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddigGroup group = new AddigGroup();
            group.ShowDialog();
        }

        private void AddSubgroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddingSubgroup subgroup = new AddingSubgroup();
            subgroup.ShowDialog();
        }

        private void GroupComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            GroupComboBox.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(GroupComboBox.Items);
            cv.Filter = s =>
                ((string)s).IndexOf(GroupComboBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
