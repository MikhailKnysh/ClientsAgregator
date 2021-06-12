using System.Collections.Generic;

namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class NewOrderInfoModel
    {
        public int ClientId { get; set; }
        public string OrderDate { get; set; }
        public int StatusesId { get; set; }
        public string OrderReview { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductInOrderModel> ProductsInOrder { get; set; }

        public override bool Equals(object obj)
        {
            return obj is NewOrderInfoModel model &&
                   ClientId == model.ClientId &&
                   OrderDate == model.OrderDate &&
                   StatusesId == model.StatusesId &&
                   OrderReview == model.OrderReview &&
                   TotalPrice == model.TotalPrice &&
                   EqualityComparer<List<ProductInOrderModel>>.Default.Equals(ProductsInOrder, model.ProductsInOrder);
        }
    }
}
