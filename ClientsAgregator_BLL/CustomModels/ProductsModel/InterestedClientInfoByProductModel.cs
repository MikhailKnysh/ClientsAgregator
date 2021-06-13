using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.ProductsModel
{
    public class InterestedClientInfoByProductModel
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
        public string AVGRate { get; set; }

        public override bool Equals(object obj)
        {
            return obj is InterestedClientInfoByProductModel model &&
                   ClientId == model.ClientId &&
                   LastName == model.LastName &&
                   FirstName == model.FirstName &&
                   MiddleName == model.MiddleName &&
                   Phone == model.Phone &&
                   BulkStatusTitle == model.BulkStatusTitle &&
                   ProductId == model.ProductId &&
                   ProductTitle == model.ProductTitle &&
                   SumQuantity == model.SumQuantity &&
                   AVGRate == model.AVGRate;
        }
    }
}
