
namespace ClientsAgregator_DAL.Models
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Rate { get; set; }
    }
}
