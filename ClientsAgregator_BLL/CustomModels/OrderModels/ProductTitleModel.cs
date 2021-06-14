using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.OrderModels
{
    public class ProductTitleModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductTitleModel model &&
                   ProductId == model.ProductId &&
                   ProductTitle == model.ProductTitle;
        }
    }
}
