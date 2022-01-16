using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.ShopModels
{
    public class Product : EntityBase
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int? TaxId { get; set; }
        public Tax Tax { get; set; }
        public bool IsLowStock { get; set; }
        public int Stock { get; set; }
        public float AdditionalShippingCost { get; set; }
        public float NettoPrice { get; set; }
        public float BruttoPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        [JsonIgnore]
        public List<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        [JsonIgnore]
        public List<OrdersProducts> OrdersProducts { get; set; }
        [JsonIgnore]
        public List<CustomerCart> CustomerCart { get; set; }
        [JsonIgnore]
        public List<ProductsPayments> ProductsPayments { get; set; }
        [JsonIgnore]
        public List<ProductsCarriers> ProductsCarriers { get; set; }
        [JsonIgnore]
        public List<ProductsTags> ProductsTags { get; set; }
        [JsonIgnore]
        public List<ProductVariant> ProductsVariants { get; set; }
        [JsonIgnore]
        public List<HomeProductsLists> HomeProductsLists { get; set; }
    }
}
