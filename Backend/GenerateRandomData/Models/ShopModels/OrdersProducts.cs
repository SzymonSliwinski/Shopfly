namespace Common.Models.ShopModels
{
    public class OrdersProducts
    {
        public int OrderId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Order Order { get; set; }
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public float ProductQuantity { get; set; }
    }
}
