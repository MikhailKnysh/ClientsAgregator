using ClientsAgregator_BLL;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_DAL.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ClientsAgregator
{
    /// <summary>
    /// Interaction logic for ProfileClientWindow.xaml
    /// </summary>
    public partial class ProfileClientWindow : Page
    {
       

        Controller controller = new Controller();
        ClientModel clientModel;
        List<ProductBuyClientModel> productsBuyClientModel;
        public int idClient;
    
        public ProfileClientWindow( int IdClient)
        {

            
            InitializeComponent();
            idClient = IdClient;
            clientModel = controller.GetClientByIdModels(idClient);
            lastNameLabel.Content = clientModel.LastName;
            firstNameLabel.Content = clientModel.FirstName;
            middleNameLabel.Content = clientModel.MiddleName;
            emailLabel.Content = clientModel.Email;
            phoneLabel.Content = clientModel.Phone;
            bulkstatusLabel.Content = clientModel.BulkStatusTitle;
            MaleLabel.Content = clientModel.Male;

            productsBuyClientModel = controller.GetProductsBuyClientModels(idClient);

            for (int i = 0; i < productsBuyClientModel.Count; i++)
            {
                clientsGrid.Items.Add(productsBuyClientModel[i]);
            }
        }
    }
}
