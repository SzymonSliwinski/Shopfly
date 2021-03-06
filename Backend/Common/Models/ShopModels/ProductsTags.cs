namespace Common.Models.ShopModels
{
    public class ProductsTags : ManyToManyEntityBase
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
