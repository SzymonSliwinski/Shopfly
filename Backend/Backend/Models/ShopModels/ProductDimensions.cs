using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class ProductDimensions
    {
        public int Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<ProductsVariants> ProductsVariants { get; set; }
    }
}
