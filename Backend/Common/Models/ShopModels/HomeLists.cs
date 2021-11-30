using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ShopModels
{
    public class HomeList : EntityBase
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public List<HomeProductsLists> HomeProductsLists { get; set; }
    }
}
