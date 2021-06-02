using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_DAL.Models
{
    public class ProductsBuyClientDTO
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int MeasureId { get; set; }
    }
}
