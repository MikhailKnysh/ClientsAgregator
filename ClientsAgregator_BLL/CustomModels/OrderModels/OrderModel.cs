using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StatusesId { get; set; }
        public string OrderReview { get; set; }
        public string OrderDate { get; set; }
        public double TotalPrice { get; set; }

    }
}
