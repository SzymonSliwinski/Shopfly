using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Photo : EntityBase
    {
        public bool IsCover { get; set; }
        public byte[] Bytes { get; set; }
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
    }
}
