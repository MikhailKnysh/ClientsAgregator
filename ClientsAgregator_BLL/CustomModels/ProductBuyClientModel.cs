namespace ClientsAgregator_BLL.CustomModels
{
    public class ProductBuyClientModel
    {
        public int ProductId { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public int SUMQuantity { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public string AVGRate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductBuyClientModel model &&
                   ProductId == model.ProductId &&
                   Articul == model.Articul &&
                   Title == model.Title &&
                   SUMQuantity == model.SUMQuantity &&
                   GroupName == model.GroupName &&
                   SubGroupName == model.SubGroupName &&
                   AVGRate == model.AVGRate;
        }
    }
}

