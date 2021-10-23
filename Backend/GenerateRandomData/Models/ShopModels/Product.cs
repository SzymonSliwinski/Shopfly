using System;
using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class Product
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Category Category { get; set; }
        public string Name { get; set; }
        public int TaxId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Tax Tax { get; set; }
        public bool IsLowStock { get; set; }
        public float AdditionalShippingCost { get; set; }
        public float NettoPrice { get; set; }
        public float BruttoPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Comment> Comments { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Rating> Ratings { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<OrdersProducts> OrdersProducts { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsPayments> ProductsPayments { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsCarriers> ProductsCarriers { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsTags> ProductsTags { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductVariant> ProductsVariants { get; set; }
    }
}
