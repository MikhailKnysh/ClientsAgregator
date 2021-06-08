
namespace ClientsAgregator_DAL.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusesId { get; set; }
        public string OrderReview { get; set; }
        public string OrderDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public double TotalPrice { get; set; }
        public string Title { get; set; }
        public string OrderReview { get; set; }
    }
}
