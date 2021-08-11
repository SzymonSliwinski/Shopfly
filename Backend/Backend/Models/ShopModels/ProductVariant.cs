namespace Backend.Models.ShopModels
{
    public class ProductVariant
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
    }
}
