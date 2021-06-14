using ClientsAgregator_BLL;
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
    /// Interaction logic for MeasureUnitWindow.xaml
    /// </summary>
    public partial class MeasureUnitWindow : Window
    {
        public MeasureUnitWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            string measureUnit = MeasureUnitTextBox.Text.Trim();

            if (ValidationData.IsValidStringLenght(measureUnit, 255) && ValidationData.IsStringNotNull(measureUnit))
            {
                Controller controller = new Controller();
                controller.AddMeasureUnuit(measureUnit);
                this.DialogResult = true;
            }
            else
            {
                MeasureUnitTextBox.Background = Brushes.Tomato;
                MeasureUnitTextBox.ToolTip = "Это поле введено некорректно";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = Mouse.GetPosition(null).Y;

            this.Left = Mouse.GetPosition(null).X;
        }
    }
}
