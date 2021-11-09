using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Photo : EntityBase
    {
        //public int Id { get; set; }
        public bool IsCover { get; set; }
        public string Path { get; set; }
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
    }
}
