using ClientsAgregator_DAL.CustomModels;
using ClientsAgregator_DAL.Models;
using System.Collections.Generic;

namespace ClientsAgregator_DAL.Interface
{
    public interface IOrdersHelper
    {
        public List<OrdersInfoDTO> GetOrdersInfo();
        public List<ClientFullNameDTO> GetClientsFullNames();
        public List<ProductSubgroupDTO> GetProductTitles();
        public List<StatusDTO> GetStatusTitles();
        public void AddOrder(List<Product_OrderDTO> productsOrder, OrderDTO order);
        public void DeleteOrder(int orderId);
        public OrderDTO GetOrdersInfoById(int orderId);
        public List<ProductInOrderDTO> GetProductsInOrderByOrderId(int orderId);
    }
}
