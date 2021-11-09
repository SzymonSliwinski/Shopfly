using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class ProductColor : EntityBase
    {
        //public int Id { get; set; }
        public string HexValue { get; set; }
        public List<ProductVariant> ProductVariants { get; set; }
    }
}
