using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Status : EntityBase
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
