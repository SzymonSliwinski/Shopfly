using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class HomeList
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<HomeProductsLists> HomeProductsLists { get; set; }
    }
}
