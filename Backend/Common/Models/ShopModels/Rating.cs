namespace Common.Models.ShopModels
{
    public class Rating : EntityBase
    {
        //public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rate { get; set; }
    }
}
