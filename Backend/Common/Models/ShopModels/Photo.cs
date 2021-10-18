using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Photo
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public bool IsCover { get; set; }
        public string Path { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
    }
}
