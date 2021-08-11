using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Carrier
    {
        public int Id { get; set; }
        public float Cost { get; set; } // todo check: ma być float czy int?
        public string Name { get; set; }    // todo length of string
        public string Logo { get; set; }
        public int DeliveryDaysMinimum { get; set; }
        public int DeliveryDaysMaximum { get; set; }
        public List<Order> Orders { get; set; }
        public List<Carrier> Carriers { get; set; }
    }
}
