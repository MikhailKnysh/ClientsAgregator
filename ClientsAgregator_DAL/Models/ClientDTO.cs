
namespace ClientsAgregator_DAL.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BulkStatusTitle { get; set; }
        public string Male { get; set; }
        public string СommentAboutСlient { get; set; }

        protected bool Equals(ClientDTO other)
        {
            return Id == other.Id && LastName == other.LastName && FirstName == other.FirstName &&
                   MiddleName == other.MiddleName && Phone == other.Phone && Email == other.Email &&
                   BulkStatusTitle == other.BulkStatusTitle && Male == other.Male &&
                   СommentAboutСlient == other.СommentAboutСlient;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClientDTO) obj);
        }
    }
}
