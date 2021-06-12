using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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
            GroupComboBox.Items.Clear();
            SubgroupComboBox.Items.Clear();
            MeasureUnitComboBox.Items.Clear();
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
            string articul = ArticulTextBox.Text;
            string title = TitelTextBox.Text;
            string quantity = QuantityTextBox.Text;
            string price = PriceTextBox.Text;

            bool isAdding = true;
            bool isTitleNotUnique = false;

            List<ProductsSubgropModel> _products = _controller.GetProductsSubgroupModels();

            foreach (UIElement item in AddProductGrid.Children)
            {
                if (item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Background = Brushes.Transparent;
                }
            }

            foreach (var product in _products)
            {
                isTitleNotUnique =  product.ProductTitle.Contains(title);
                
                if(isTitleNotUnique)
                {

                    break;
                }
            }

            if (!(ValidationData.IsValidStringLenght(articul, 255)))
            {
                ArticulTextBox.ToolTip = "Это поле введено некорректно";
                ArticulTextBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsValidStringLenght(title, 255))
                || !(ValidationData.IsStringNotNull(title))
                || (isTitleNotUnique))
            {
                TitelTextBox.ToolTip = "Это поле введено некорректно или название продукта не уникально";
                TitelTextBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsNumber(quantity))
                || !(ValidationData.IsStringNotNull(quantity)))
            {
                QuantityTextBox.ToolTip = "Это поле введено некорректно";
                QuantityTextBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsNumber(price))
                || !(ValidationData.IsStringNotNull(price)))
            {
                PriceTextBox.ToolTip = "Это поле введено некорректно";
                PriceTextBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(SubgroupComboBox.Text.Trim())))
            {
                SubgroupComboBox.ToolTip = "Это поле введено некорректно";
                SubgroupComboBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(GroupComboBox.Text.Trim())))
            {
                GroupComboBox.ToolTip = "Это поле введено некорректно";
                GroupComboBox.Background = Brushes.Tomato;
                isAdding = false;
            }

            if (!(ValidationData.IsStringNotNull(MeasureUnitComboBox.Text.Trim())))
            {
                MeasureUnitComboBox.ToolTip = "Это поле введено некорректно";
                MeasureUnitComboBox.Background = Brushes.Tomato;
                isAdding = false;
            }


            if (isAdding)
            {
                MeasureUnitInfoModel measureUnitModel = measureUnitInfoModels[MeasureUnitComboBox.SelectedIndex];
                SubgroupInfoModel subgroupModel = subgroupInfoModels[SubgroupComboBox.SelectedIndex];
                AddingProductModel addingProductModel = new AddingProductModel()
                {
                    Articul = articul,
                    Title = title,
                    Quantity = Convert.ToInt32(quantity),
                    Price = Convert.ToDouble(price),
                    MeasureId = measureUnitModel.Id,
                    SubgroupId = subgroupModel.Id
                };

                _controller.AddProduct(addingProductModel);

                foreach (UIElement element in AddProductGrid.Children)
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

                MessageBox.Show("Товар успешно добавлен");
            }
        }

        private void AddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddigGroup group = new AddigGroup();
            if (group.ShowDialog() == true)
            {
                AddingProductWindow_Loaded(sender, e);
            }
        }

        private void AddSubgroupButton_Click(object sender, RoutedEventArgs e)
        {
            AddingSubgroup subgroup = new AddingSubgroup();
            if (subgroup.ShowDialog() == true)
            {
                AddingProductWindow_Loaded(sender, e);
            }
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

        private void AddMeasureUnitButton_Click(object sender, RoutedEventArgs e)
        {
            MeasureUnitWindow measureUnitWindow = new MeasureUnitWindow();

            if (measureUnitWindow.ShowDialog() == true)
            {
                AddingProductWindow_Loaded(sender, e); 
            }
        }
    }
}
