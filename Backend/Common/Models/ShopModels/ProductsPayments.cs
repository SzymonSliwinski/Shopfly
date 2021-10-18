namespace Common.Models.ShopModels
{
    public class ProductsPayments
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
