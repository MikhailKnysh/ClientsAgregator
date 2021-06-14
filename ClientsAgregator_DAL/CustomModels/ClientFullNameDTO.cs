using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.CustomModels
{
    public class ClientFullNameDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        protected bool Equals(ClientFullNameDTO other)
        {
            return Id == other.Id && LastName == other.LastName && FirstName == other.FirstName &&
                   MiddleName == other.MiddleName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ClientFullNameDTO) obj);
        }
    }
}
