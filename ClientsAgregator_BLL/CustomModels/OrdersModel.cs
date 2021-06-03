using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusesId { get; set; }
        public string SellerComment { get; set; }
        public string OrderDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
