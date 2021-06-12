using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.ProductsModel
{
    public class ProductsSubgropModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int SubgroupId { get; set; }
        public string SubgroupTitle { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductsSubgropModel model &&
                   ProductId == model.ProductId &&
                   ProductTitle == model.ProductTitle &&
                   SubgroupId == model.SubgroupId &&
                   SubgroupTitle == model.SubgroupTitle;
        }
    }
}
