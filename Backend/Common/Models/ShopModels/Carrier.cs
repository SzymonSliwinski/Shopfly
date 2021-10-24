using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Carrier
    {
        public int Id { get; set; }
        public float Cost { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int DeliveryDaysMinimum { get; set; }
        public int DeliveryDaysMaximum { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductsCarriers> ProductsCarriers { get; set; }
        public bool IsActive { get; set; }
    }
}
