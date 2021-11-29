namespace Common.Models.ShopModels
{
    public class ProductsVariantsPhotos : ManyToManyEntityBase
    {
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
