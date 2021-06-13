using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.CustomModels
{
    public class OrdersInfoDTO
    {
        public int Id { get; set; }
        public string OrderDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public double TotalPrice { get; set; }
        public string Title { get; set; }
        public string OrderReview { get; set; }

        public override bool Equals(object obj)
        {
            return obj is OrdersInfoDTO model &&
                   Id == model.Id &&
                   OrderDate == model.OrderDate &&
                   LastName == model.LastName &&
                   FirstName == model.FirstName &&
                   MiddleName == model.MiddleName &&
                   TotalPrice == model.TotalPrice &&
                   Title == model.Title &&
                   OrderReview == model.OrderReview;
        }
    }
}
