using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels
{
    class ProductBuyClientAndRateModel
    {
        public string Articul { get; set; }
        public string Title { get; set; }
        public int SUMQuantity { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public string AVGRate { get; set; }
    }
}
