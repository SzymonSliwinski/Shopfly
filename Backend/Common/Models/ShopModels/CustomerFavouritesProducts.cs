namespace Common.Models.ShopModels
{
    public class CustomerFavouritesProducts : ManyToManyEntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
