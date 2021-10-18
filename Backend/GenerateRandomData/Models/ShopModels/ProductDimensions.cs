using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class ProductDimensions
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductVariant> ProductsVariants { get; set; }
    }
}
