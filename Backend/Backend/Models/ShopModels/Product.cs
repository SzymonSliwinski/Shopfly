﻿using System;
using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }    // todo lenght of string
        public int TaxId { get; set; }
        public Tax Tax { get; set; }
        public bool IsLowStock { get; set; }
        public float AdditionalShippingCost { get; set; }   // todo optional
        public float NettoPrice { get; set; }
        public float BruttoPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        public List<OrdersProducts> OrdersProducts { get; set; }
        public List<ProductsCarriers> ProductsCarriers { get; set; }
        public List<ProductsTags> ProductsTags { get; set; }
}