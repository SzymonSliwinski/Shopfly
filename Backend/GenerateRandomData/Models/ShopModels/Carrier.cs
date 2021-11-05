using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class Carrier
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public float Cost { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int DeliveryDaysMinimum { get; set; }
        public int DeliveryDaysMaximum { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Order> Orders { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsCarriers> ProductsCarriers { get; set; }
        public bool IsActive { get; set; }
    }
}
