﻿using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class ProductColor
    {
        public int Id { get; set; }
        public string HexValue { get; set; }    // todo length of string
        public List<ProductVariant> ProductVariants { get; set; }
    }
}