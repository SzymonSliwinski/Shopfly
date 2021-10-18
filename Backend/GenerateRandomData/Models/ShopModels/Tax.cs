using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Tax
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Interest { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
