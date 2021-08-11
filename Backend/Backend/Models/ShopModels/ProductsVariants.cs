namespace Backend.Models.ShopModels
{
    public class ProductsVariants
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public ProductColor Color { get; set; }
        public int DiemensionsId { get; set; }
        public ProductDimensions Dimension { get; set; }
        public float Price { get; set; }
        public bool IsOnSale { get; set; }
        public int SalePercentage { get; set; }
        public int Quantity { get; set; }
    }
}
