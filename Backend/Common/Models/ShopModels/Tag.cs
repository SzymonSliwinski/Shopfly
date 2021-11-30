using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }
        public List<ProductsTags> ProductsTags { get; set; }
    }
}
