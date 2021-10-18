namespace GenerateRandomData.Models.ShopModels
{
    public class Rating
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public int Rate { get; set; }
    }
}
