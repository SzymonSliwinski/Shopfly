namespace Common.Models.ShopModels
{
    public class ProductsPayments
    {
        public int ProductId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Product Product { get; set; }
        public int PaymentTypeId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public PaymentType PaymentType { get; set; }
    }
}
