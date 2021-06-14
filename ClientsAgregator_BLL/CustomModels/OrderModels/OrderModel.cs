namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusesId { get; set; }
        public string OrderReview { get; set; }
        public string OrderDate { get; set; }
        public double TotalPrice { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderModel model &&
                   Id == model.Id &&
                   ClientId == model.ClientId &&
                   StatusesId == model.StatusesId &&
                   OrderReview == model.OrderReview &&
                   OrderDate == model.OrderDate &&
                   TotalPrice == model.TotalPrice;
        }
    }
}
