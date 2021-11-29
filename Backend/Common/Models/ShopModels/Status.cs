using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Status : EntityBase
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
