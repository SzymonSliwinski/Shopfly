using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public List<Order> Orders { get; set; }
    }
}
