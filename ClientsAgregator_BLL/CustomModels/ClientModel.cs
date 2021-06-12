using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BulkStatusTitle { get; set; }
        public string Male { get; set; }
        public string СommentAboutСlient { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ClientModel model &&
                   Id == model.Id &&
                   LastName == model.LastName &&
                   FirstName == model.FirstName &&
                   MiddleName == model.MiddleName &&
                   Phone == model.Phone &&
                   Email == model.Email &&
                   BulkStatusTitle == model.BulkStatusTitle &&
                   Male == model.Male &&
                   СommentAboutСlient == model.СommentAboutСlient;
        }
    }
}
