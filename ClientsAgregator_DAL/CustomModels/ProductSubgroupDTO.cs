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
    }
}
