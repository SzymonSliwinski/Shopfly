namespace Common.Models.ShopModels
{
    public class Comment
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public string Content { get; set; }
    }
}
