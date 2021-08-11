using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class ProductsCarriers
    {
        public int ProductId { get; set; }
        public List<Product> Products { get; set; }
        public int CarrierId { get; set; }
        public List<Carrier> Carriers { get; set; }
    }
}
