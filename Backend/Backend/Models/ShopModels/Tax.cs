using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Tax
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public int Interest { get; set; }
        public List<Product> Products { get; set; }
    }
}
