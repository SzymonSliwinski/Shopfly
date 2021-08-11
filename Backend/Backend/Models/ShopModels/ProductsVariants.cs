namespace Backend.Models.ShopModels
{
    public class ProductsVariants
    {
        // todo prawdopodobnie ta klasa jest zbędna
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int VariantId { get; set; }
        public ProductVariant Variant { get; set; }
    }
}
