namespace GenerateRandomData.Models.ShopModels
{
    public class HomeProductsLists
    {
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public int ListId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public HomeList HomeList { get; set; }
    }
}
