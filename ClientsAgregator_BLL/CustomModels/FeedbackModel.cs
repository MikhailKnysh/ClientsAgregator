using System;

namespace ClientsAgregator_BLL.CustomModels
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Rate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FeedbackModel model &&
                   Id == model.Id &&
                   ClientId == model.ClientId &&
                   ProductId == model.ProductId &&
                   Description == model.Description &&
                   Date == model.Date &&
                   Rate == model.Rate;
        }
        
    }
}
