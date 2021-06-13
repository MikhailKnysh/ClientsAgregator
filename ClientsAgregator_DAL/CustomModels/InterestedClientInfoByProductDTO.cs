using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.CustomModels
{
    public class InterestedClientInfoByProductDTO
    {
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string BulkStatusTitle { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int SumQuantity { get; set; }
        public int AVGRate { get; set; }

        protected bool Equals(InterestedClientInfoByProductDTO other)
        {
            return ClientId == other.ClientId && LastName == other.LastName && FirstName == other.FirstName &&
                   MiddleName == other.MiddleName && Phone == other.Phone && BulkStatusTitle == other.BulkStatusTitle &&
                   ProductId == other.ProductId && ProductTitle == other.ProductTitle &&
                   SumQuantity == other.SumQuantity && AVGRate == other.AVGRate;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((InterestedClientInfoByProductDTO) obj);
        }
    }
}
