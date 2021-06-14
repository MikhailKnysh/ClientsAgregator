using System;
using System.Collections.Generic;
using System.Text;
using ClientsAgregator_BLL.CustomModels;
using ClientsAgregator_BLL.CustomModels.OrderModels;
using ClientsAgregator_BLL.CustomModels.ProductsModel;

namespace ClientsAgregator_BLL
{
    public interface IController
    {
        public List<ClientsFullNameModel> GetClientsFullNameModels();
        public List<ProductTitleModel> GetProductTitlesModels();
        public List<StatusModel> GetStatusModels();
        public void AddOrder(NewOrderInfoModel newOrderInfoModel, List<FeedbackModel> feedbackModels);
        public void UpdateOrder(NewOrderInfoModel newOrderInfoModel, int orderId, List<FeedbackModel> feedbackModels);
        public void DeleteOrder(int orderId);
        public List<ProductInfoModel> GetProductInfoModels();
        public List<GroupInfoModel> GetGroups();
        public List<SubgroupInfoModel> GetSubgroupsInfoByGroupId(int groupId);
        public List<MeasureUnitInfoModel> GetMeasureUnit();
        public void AddProduct(AddingProductModel addingProductModel);
        public void AddGroup(string groupTitle);
        public void AddMeasureUnuit(string measureUnitTitle);
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
        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoByProduct(int productId);
        public List<InterestedClientInfoByProductModel> GetInterestedClientInfoBySubgroup(int subgroupId);
        public int GetSpendMoneyCountByClientIdModels(int Id);
        public List<FeedbackModel> GetFeedbackModels();
        public OrderModel GetOrdersInfoById(int orderId);
        public List<ProductInOrderModel> GetProductsInOrderByOrderId(int orderId);
    }
}
