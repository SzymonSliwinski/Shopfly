namespace GenerateRandomData.Models.ShopModels
{
    public class ProductsVariantsPhotos
    {
        public int ProductVariantId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public ProductVariant ProductVariant { get; set; }
        public int PhotoId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Photo Photo { get; set; }
    }
}
