using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class Status
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
