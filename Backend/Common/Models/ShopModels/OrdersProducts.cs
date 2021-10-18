namespace Common.Models.ShopModels
{
    public class OrdersProducts
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public float ProductQuantity { get; set; }
    }
}
