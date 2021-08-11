namespace Backend.Models.ShopModels
{
    public class Comment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        // todo zmiana w stosunku do modelu Comment -> CommentText:
        public string CommentText { get; set; } // todo length of string
    }
}
