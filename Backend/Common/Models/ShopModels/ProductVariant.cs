using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public ProductColor Color { get; set; }
        public int DimensionId { get; set; }        // tutaj poprawiłem literówkę
        public ProductDimensions Dimension { get; set; }
        public float Price { get; set; }
        public bool IsOnSale { get; set; }
        public int SalePercentage { get; set; }
        public int Quantity { get; set; }
        public List<ProductsVariantsPhotos> ProductsVariantsPhotos { get; set; }
        public Product Product { get; set; }
    }
}
