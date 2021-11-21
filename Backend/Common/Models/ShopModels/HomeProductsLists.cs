using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ShopModels
{
    public class HomeProductsLists
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ListId { get; set; }
        public HomeList HomeList { get; set; }

    }
}
