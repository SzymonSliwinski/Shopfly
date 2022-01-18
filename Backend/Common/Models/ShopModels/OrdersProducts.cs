using System.Text.Json.Serialization;

namespace Common.Models.ShopModels
{
    public class OrdersProducts : ManyToManyEntityBase
    {
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public float ProductQuantity { get; set; }
    }
}
