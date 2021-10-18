using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class ProductVariant
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public int ColorId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ProductColor Color { get; set; }
        public int DimensionId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public int DimensionId { get; set; }
        public ProductDimensions Dimension { get; set; }
        public float Price { get; set; }
        public bool IsOnSale { get; set; }
        public int SalePercentage { get; set; }
        public int Quantity { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
