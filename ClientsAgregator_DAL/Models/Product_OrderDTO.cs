
using System;

namespace ClientsAgregator_DAL.Models
{
    public class Product_OrderDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        protected bool Equals(Product_OrderDTO other)
        {
            return Id == other.Id && OrderId == other.OrderId && ProductId == other.ProductId && Quantity == other.Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product_OrderDTO) obj);
        }
    }


}
