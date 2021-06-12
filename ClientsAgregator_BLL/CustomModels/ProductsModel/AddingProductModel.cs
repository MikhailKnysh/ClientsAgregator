using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.ProductsModel
{
    public class AddingProductModel
    {
        public string Articul { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int MeasureId { get; set; }
        public int SubgroupId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddingProductModel model &&
                   Articul == model.Articul &&
                   Title == model.Title &&
                   Price == model.Price &&
                   Quantity == model.Quantity &&
                   MeasureId == model.MeasureId &&
                   SubgroupId == model.SubgroupId;
        }
    }
}
