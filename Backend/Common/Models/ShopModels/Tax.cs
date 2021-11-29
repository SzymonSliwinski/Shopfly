using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Tax : EntityBase
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Interest { get; set; }
        public List<Product> Products { get; set; }
    }
}
