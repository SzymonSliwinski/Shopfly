using System.Text.Json.Serialization;

namespace Common.Models.ShopModels
{
    public class Rating : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int Rate { get; set; }
    }
}
