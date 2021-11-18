using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ShopModels
{
    public class ProductListPhoto
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public HomeProductsLists List { get; set; }
        public string Photo { get; set; }
    }
}
