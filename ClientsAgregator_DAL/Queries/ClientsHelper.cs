using ClientsAgregator_DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ClientsAgregator_DAL.Queries
{
    public static class ClientsHelper
    {
        public static void AddClient(AddClientDTO addClientDTO)
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
                    addClientDTO.СommentAboutСlient
                });
            }
        }

        public static List<ClientDTO> GetClients()
        {
            string query = "ClientsAgregatorDB.GetClients";

            List<ClientDTO> clientsInfo = new List<ClientDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clientsInfo = conn.Query<ClientDTO>(query).AsList();
            }

            return clientsInfo;
        }

        public static ClientDTO GetClientById(int id)
        {
            string query = "ClientsAgregatorDB.GetClientById @Id";

            ClientDTO clientInfo = new ClientDTO();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                clientInfo = conn.Query<ClientDTO>(query, new { id }).AsList<ClientDTO>().FirstOrDefault<ClientDTO>();
            }

            return clientInfo;
        }

        public static List<ProductsBuyClientDTO> GetProductsBuyClient(int id)
        {
            string query = "ClientsAgregatorDB.GetProductBuyClientById @Id";

            List<ProductsBuyClientDTO> productsBuyClient = new List<ProductsBuyClientDTO>();

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                productsBuyClient = conn.Query<ProductsBuyClientDTO>(query, new { id }).AsList();
            }

            return productsBuyClient;
        }

        public static void UpdateClientById(AddClientDTO addClientDTO, int Id)
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
                    addClientDTO.СommentAboutСlient
                });
            }
        }

        public static string GetSpendMoneyCountByClientId(int id)           //НУЖНО ЛИ ЭТО ДЕЛАТЬ В ЛОГИКЕ ИЛИ СЧИТАТЬ В SQL??? 
        {
            string query = "ClientsAgregatorDB.GetSpendMoneyCountByClientId";

            string totalSum;

            using (IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                totalSum = conn.Query<int>(query, new { id }).ToString();
            }

            return totalSum;
        }

        public static List<BulkStatusDTO> GetBulkStatuses()
        {
            string query = "ClientsAgregatorDB.GetBulkStatuses";

            List<BulkStatusDTO> bulkStatusInfo = new List<BulkStatusDTO>();

            using(IDbConnection conn = new SqlConnection(Options.connectionString))
            {
                bulkStatusInfo = conn.Query<BulkStatusDTO>(query).AsList();
            }

            return bulkStatusInfo;
        }
    }
}
