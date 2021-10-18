namespace GenerateRandomData.Models.ShopModels
{
    public class CustomerFavouritesProducts
    {
        public int CustomerId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
    }
}
