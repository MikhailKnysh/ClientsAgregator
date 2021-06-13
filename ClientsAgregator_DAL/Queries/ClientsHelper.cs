using ClientsAgregator_DAL.Interface;
using ClientsAgregator_DAL.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ClientsAgregator_DAL.Queries
{
    public class ClientsHelper : IClientsHelper
    {
        public void AddClient(AddClientDTO addClientDTO)
        {
            string query = "ClientsAgregatorDB.AddClient @LastName, @FirstName," +
                " @MiddleName,  @Phone, @Email," +
                " @BulkStatusId, @Male, @СommentAboutСlient";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query(query, new
                {
                    addClientDTO.LastName,
                    addClientDTO.FirstName,
                    addClientDTO.MiddleName,
                    addClientDTO.Phone,
                    addClientDTO.Email,
                    addClientDTO.BulkStatusId,
                    addClientDTO.Male,
                    addClientDTO.CommentAboutClient
                });
            }
        }

        public List<ClientDTO> GetClients()
        {
            string query = "ClientsAgregatorDB.GetClients";

            List<ClientDTO> clientsInfo = new List<ClientDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clientsInfo = conn.Query<ClientDTO>(query).AsList();
            }

            return clientsInfo;
        }

        public ClientDTO GetClientById(int id)
        {
            string query = "ClientsAgregatorDB.GetClientById @Id";

            ClientDTO clientInfo = new ClientDTO();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clientInfo = conn.Query<ClientDTO>(query, new { id }).AsList<ClientDTO>().FirstOrDefault<ClientDTO>();
            }

            return clientInfo;
        }

        public List<ProductsBuyClientDTO> GetProductsBuyClient(int id)
        {
            string query = "ClientsAgregatorDB.GetProductBuyClientById @Id";

            List<ProductsBuyClientDTO> productsBuyClient = new List<ProductsBuyClientDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productsBuyClient = conn.Query<ProductsBuyClientDTO>(query, new { id }).AsList();
            }

            return productsBuyClient;
        }

        public void UpdateClientById(AddClientDTO addClientDTO, int Id)
        {
            string query = "ClientsAgregatorDB.UpdateClientById @Id, @LastName, @FirstName," +
                " @MiddleName, @Phone, @Email," +
                " @BulkStatusId, @Male, @СommentAboutСlient";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                conn.Query(query,  new
                {
                    Id,
                    addClientDTO.LastName,
                    addClientDTO.FirstName,
                    addClientDTO.MiddleName,
                    addClientDTO.Phone,
                    addClientDTO.Email,
                    addClientDTO.BulkStatusId,
                    addClientDTO.Male,
                    addClientDTO.CommentAboutClient
                });
            }
        }

        public int GetSpendMoneyCountByClientId(int id)
        {
            string query = "ClientsAgregatorDB.GetSpendMoneyCountByClientId";

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
               var totalSum = conn.Query<int>(query, new { id }, commandType: CommandType.StoredProcedure);
            
                return totalSum.Single();
            }

        }

        public List<BulkStatusDTO> GetBulkStatuses()
        {
            string query = "ClientsAgregatorDB.GetBulkStatuses";

            List<BulkStatusDTO> bulkStatusInfo = new List<BulkStatusDTO>();

            using(IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                bulkStatusInfo = conn.Query<BulkStatusDTO>(query).AsList();
            }

            return bulkStatusInfo;
        }

        public  List<FeedbackDTO> GetFeedbacks()
        { 
            string query = "ClientsAgregatorDB.GetFeedbacks";
            List<FeedbackDTO> feedbacks = new List<FeedbackDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                feedbacks = conn.Query<FeedbackDTO>(query).AsList();
            }

            return feedbacks;
        }
        public FeedbackDTO GetFeedbackClientById(int id)
        {
            string query = "ClientsAgregatorDB.GetFeedbacks";
            FeedbackDTO feedback = new FeedbackDTO();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                feedback = conn.Query<FeedbackDTO>(query, new { id}, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return feedback;
        }
    }
}
