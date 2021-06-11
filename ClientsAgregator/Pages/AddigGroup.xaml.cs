using ClientsAgregator_BLL;
using System.Windows;

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

            if (ValidationData.IsValidStringLenght(group, validCharQuantity: 255))
            {
                controller.AddGroup(GroupTextBox.Text);
                this.DialogResult = false;
            }
            else
            {
                GroupTextBox.Background = Brushes.Tomato;
                GroupTextBox.ToolTip = "Это поле введено некорректно";
            }
            controller.AddGroup(GroupTextBox.Text);
            this.DialogResult = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}