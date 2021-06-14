
namespace ClientsAgregator_DAL.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public int MeasureId { get; set; }

        protected bool Equals(ProductDTO other)
        {
            return Id == other.Id && Articul == other.Articul && Title == other.Title && Price.Equals(other.Price) &&
                   Quantity == other.Quantity && MeasureId == other.MeasureId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductDTO) obj);
        }
    }
}
