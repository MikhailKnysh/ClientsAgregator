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
        public int SumQuantity { get; set; }
        public int AVGRate { get; set; }
    }
}
