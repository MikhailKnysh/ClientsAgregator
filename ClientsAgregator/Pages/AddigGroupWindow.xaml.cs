using ClientsAgregator_BLL;
using System.Windows;
using System.Windows.Media;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for AddigGroup.xaml
    /// </summary>
    public partial class AddigGroup : Window
    {
        public AddigGroup()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();

            string group = GroupTextBox.Text.Trim();

            if (ValidationData.IsValidStringLenght(group, validCharQuantity: 255) && ValidationData.IsStringNotNull(group))
            {
                controller.AddGroup(group);
                this.DialogResult = true;
            }
            else
            {
                GroupTextBox.Background = Brushes.Tomato;
                GroupTextBox.ToolTip = "Это поле введено некорректно";
            }
        }
    }
}