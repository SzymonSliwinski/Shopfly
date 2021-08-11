﻿using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class ProductsCarriers
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}
