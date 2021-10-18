using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Tag
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsTags> ProductsTags { get; set; }
    }
}
