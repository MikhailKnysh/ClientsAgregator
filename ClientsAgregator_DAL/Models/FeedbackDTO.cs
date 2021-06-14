
namespace ClientsAgregator_DAL.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Rate { get; set; }

        protected bool Equals(FeedbackDTO other)
        {
            return Id == other.Id && ClientId == other.ClientId && ProductId == other.ProductId &&
                   Description == other.Description && Date == other.Date && Rate == other.Rate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FeedbackDTO) obj);
        }
    }
}
