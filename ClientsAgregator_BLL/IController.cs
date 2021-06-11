using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;
using System.Collections.Generic;

namespace ClientsAgregator_BLL
{
    interface IController
    {
        public List<ClientsFullNameModel> GetClientsFullNameModels();
        public List<ProductTitleModel> GetProductTitlesModels();
        public List<StatusModel> GetStatusModels();
        public void AddOrder(NewOrderInfoModel newOrderInfoModel);
        public void DeleteOrder(int orderId);
        public List<ProductInfoModel> GetProductInfoModels();
        public List<GroupInfoModel> GetGroups();
        public List<SubgroupInfoModel> GetSubgroupsInfoByGroupId(int groupId);
        public List<MeasureUnitInfoModel> GetMeasureUnit();
        public void AddProduct(AddingProductModel addingProductModel);
        public void AddGroup(string groupTitle);
        public void AddSubgropGroup(int groupId, string subgroupTitle);
        public void DeleteProduct(int productId);
        public List<OrdersInfoModel> GetOrderModels();
        public void AddClientDTO(AddClientModel model);
        public void UpdateClientDTO(AddClientModel model, int Id);
        public List<ClientModel> GetClientsModels();
        public List<ProductBuyClientModel> GetProductsBuyClientModels(int Id);
        public ClientModel GetClientByIdModels(int Id);
        public List<BulkStatusModel> GetBulkStatusesModels();
        public ProductInfoModel GetProductInfoModel(int productId);
        public List<ProductsSubgropModel> GetProductsSubgroupModels();
        public List<InterestedClientInfoByProductModel> GetMainModels(int productId);
        public int GetSpendMoneyCountByClientIdModels(int Id);
        public List<FeedbackModel> GetFeedbackModels();
    }
}
