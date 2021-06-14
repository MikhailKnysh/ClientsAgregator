
using System;

namespace ClientsAgregator_DAL.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusesId { get; set; }
        public string OrderReview { get; set; }
        public string OrderDate { get; set; }
        public double TotalPrice { get; set; }

        protected bool Equals(OrderDTO other)
        {
            return Id == other.Id && ClientId == other.ClientId && StatusesId == other.StatusesId && OrderReview == other.OrderReview && OrderDate == other.OrderDate && TotalPrice.Equals(other.TotalPrice);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderDTO) obj);
        }
    }
}
