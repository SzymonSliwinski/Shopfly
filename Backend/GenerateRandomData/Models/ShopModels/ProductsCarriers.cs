using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class ProductsCarriers
    {
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public int CarrierId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Carrier Carrier { get; set; }
    }
}
