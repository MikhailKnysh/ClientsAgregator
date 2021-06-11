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
            Controller controller = new Controller();
            controller.AddMeasureUnuit(MeasureUnitTextBox.Text);
            this.DialogResult = true;
        }
    }
}
