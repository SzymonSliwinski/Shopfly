﻿using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public List<ProductsTags> ProductsTags { get; set; }
    }
}
