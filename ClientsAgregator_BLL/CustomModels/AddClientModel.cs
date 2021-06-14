using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels
{
    public class AddClientModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int BulkStatusId { get; set; }
        public string Male { get; set; }
        public string CommentAboutClient { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddClientModel model &&
                   LastName == model.LastName &&
                   FirstName == model.FirstName &&
                   MiddleName == model.MiddleName &&
                   Phone == model.Phone &&
                   Email == model.Email &&
                   BulkStatusId == model.BulkStatusId &&
                   Male == model.Male &&
                   CommentAboutClient == model.CommentAboutClient;
        }
    }
}
