
namespace ClientsAgregator_DAL.Models
{
    public class Product_OrderDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
