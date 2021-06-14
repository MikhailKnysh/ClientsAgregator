namespace ClientsAgregator_DAL.CustomModels
{
    public class ProductInOrderDTO
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
        public string OrderReview { get; set; }

        protected bool Equals(ProductInOrderDTO other)
        {
            return Articul == other.Articul && ProductId == other.ProductId && ProductTitle == other.ProductTitle &&
                   Price.Equals(other.Price) && Quantity == other.Quantity && MeasureUnitId == other.MeasureUnitId &&
                   MeasureUnitTitle == other.MeasureUnitTitle && GroupTitle == other.GroupTitle &&
                   SubgroupTitle == other.SubgroupTitle && Rate == other.Rate && OrderReview == other.OrderReview;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductInOrderDTO) obj);
        }

    }
}
