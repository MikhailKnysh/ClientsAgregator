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

        protected bool Equals(NewOrderInfoModel other)
        {
            return ClientId == other.ClientId && OrderDate == other.OrderDate && StatusesId == other.StatusesId &&
                   OrderReview == other.OrderReview && TotalPrice.Equals(other.TotalPrice) &&
                   Equals(ProductsInOrder, other.ProductsInOrder);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NewOrderInfoModel) obj);
        }
    }
}
