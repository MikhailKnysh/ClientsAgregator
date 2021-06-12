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
    }
}
