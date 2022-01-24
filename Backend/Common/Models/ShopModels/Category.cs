using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models.ShopModels
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public bool IsRoot { get; set; }
        public int? ParentCategoryId { get; set; }
        [JsonIgnore]
        public Category ParentCategory { get; set; }
        public List<Category> ChildrensCategories { get; set; }
        public int Position { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
