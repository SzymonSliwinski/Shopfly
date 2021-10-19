using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopModels
{
    public class Category
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRoot { get; set; }
        public int ParentCategoryId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Category ParentCategory { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Category> ChildrensCategories { get; set; }
        public int Position { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
