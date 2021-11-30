using System;

namespace Common.Models.ShopModels
{
    public class Comment : EntityBase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
