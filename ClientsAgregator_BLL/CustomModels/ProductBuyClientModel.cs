using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels
{
    public class ProductBuyClientModel
    {
        public string Articul { get; set; }
        public string Title { get; set; }
        public int SUMQuantity { get; set; }
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public float AVGRate { get; set; }
    }
}

