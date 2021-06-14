namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class OrderProductModel
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int MeasureId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrderProductModel model &&
                   Id == model.Id &&
                   Articul == model.Articul &&
                   Title == model.Title &&
                   Price == model.Price &&
                   Quantity == model.Quantity &&
                   MeasureId == model.MeasureId;
        }
    }
}
