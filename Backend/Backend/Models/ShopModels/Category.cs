﻿using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } // todo length of string
        public bool IsRoot { get; set; }
        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> ChildrensCategories { get; set; }
        public int Position { get; set; }
        public List<Product> Products { get; set; }
    }
}