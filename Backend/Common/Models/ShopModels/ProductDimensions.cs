using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class ProductDimensions : EntityBase
    {
        //public int Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public List<ProductVariant> ProductsVariants { get; set; }
    }
}
