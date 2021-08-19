using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductsTags> ProductsTags { get; set; }
    }
}
