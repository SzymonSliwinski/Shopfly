namespace Backend.Models.ShopModels
{
    public class Rating
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rate { get; set; }
    }
}
