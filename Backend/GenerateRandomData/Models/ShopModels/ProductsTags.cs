namespace GenerateRandomData.Models.ShopModels
{
    public class ProductsTags
    {
        public int TagId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Tag Tag { get; set; }
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
    }
}
