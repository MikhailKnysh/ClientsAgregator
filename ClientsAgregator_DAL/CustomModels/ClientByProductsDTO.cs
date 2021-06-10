using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.CustomModels
{
    public class ClientByProductsDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int SUMQuantity { get; set; }
        public int BulkStatusId { get; set; }
        public float AVGRate { get; set; }
        public string СommentAboutСlient { get; set; }
    }
}
