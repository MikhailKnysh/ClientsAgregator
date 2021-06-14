using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.CustomModels
{
    public class ProductSubgroupDTO
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int SubgroupId { get; set; }
        public string SubgroupTitle { get; set; }

        protected bool Equals(ProductSubgroupDTO other)
        {
            return ProductId == other.ProductId && ProductTitle == other.ProductTitle &&
                   SubgroupId == other.SubgroupId && SubgroupTitle == other.SubgroupTitle;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductSubgroupDTO) obj);
        }
    }
}
