using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductsPayments> ProductsPayments { get; set; }
    }
}
