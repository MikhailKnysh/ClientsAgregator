﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClientsAgregator_BLL.CustomModels.ProductsModel
{
    public class ProductInfoModel
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int MeasureUnitId { get; set; }
        public string MeasureUnit { get; set; }
        public string Subgroup { get; set; }
        public string Group { get; set; }
    }
}
