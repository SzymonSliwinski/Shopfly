using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Photo
    {
        public int Id { get; set; }
        public bool IsCover { get; set; }
        public string Path { get; set; } // todo length of string
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
    }
}
