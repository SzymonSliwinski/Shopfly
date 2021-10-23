using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class ProductColor
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string HexValue { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductVariant> ProductVariants { get; set; }
    }
}
