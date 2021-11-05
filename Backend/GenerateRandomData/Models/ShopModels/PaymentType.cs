using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class PaymentType
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Order> Orders { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsPayments> ProductsPayments { get; set; }
        public bool IsActive { get; set; }
    }
}
