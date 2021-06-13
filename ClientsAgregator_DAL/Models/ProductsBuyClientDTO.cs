using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.Models
{
    public class ProductsBuyClientDTO
    {
        public int ProductId { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public int SUMQuantity { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }

        protected bool Equals(ProductsBuyClientDTO other)
        {
            return ProductId == other.ProductId && Articul == other.Articul && Title == other.Title &&
                   SUMQuantity == other.SUMQuantity && GroupName == other.GroupName &&
                   SubGroupName == other.SubGroupName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductsBuyClientDTO) obj);
        }
    }
}
