
namespace ClientsAgregator_DAL.Models
{
    public class MeasureUnitDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        protected bool Equals(MeasureUnitDTO other)
        {
            return Id == other.Id && Title == other.Title;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MeasureUnitDTO) obj);
        }
    }
}
