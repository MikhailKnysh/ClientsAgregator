using ClientsAgregator_DAL.Models;
using System.Collections.Generic;

namespace ClientsAgregator_DAL.Interface
{
    public interface IClientsHelper
    {
        public void AddClient(AddClientDTO addClientDTO);
        public List<ClientDTO> GetClients();
        public ClientDTO GetClientById(int id);
        public List<ProductsBuyClientDTO> GetProductsBuyClient(int id);
        public void UpdateClientById(AddClientDTO addClientDTO, int Id);
        public int GetSpendMoneyCountByClientId(int id);
        public List<BulkStatusDTO> GetBulkStatuses();
        public List<FeedbackDTO> GetFeedbacks();
        public FeedbackDTO GetFeedbackClientById(int id);
    }
}
