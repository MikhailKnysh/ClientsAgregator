namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class ProductInOrderModel
    {
        public string Articul { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int MeasureUnitId { get; set; }
        public string MeasureUnitTitle { get; set; }
        public string GroupTitle { get; set; }
        public string SubgroupTitle { get; set; }
        public int Rate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductInOrderModel model &&
                   Articul == model.Articul &&
                   ProductId == model.ProductId &&
                   ProductTitle == model.ProductTitle &&
                   Price == model.Price &&
                   Quantity == model.Quantity &&
                   MeasureUnitId == model.MeasureUnitId &&
                   MeasureUnitTitle == model.MeasureUnitTitle &&
                   GroupTitle == model.GroupTitle &&
                   SubgroupTitle == model.SubgroupTitle &&
                   Rate == model.Rate;
        }
    }
}
