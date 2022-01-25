using Common.Models.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Services
{
    public class CategoryService
    {
        public CategoryService() { }

        public void TraverseCategories(Category category, List<int> ids)
        {
            ids.Add(category.Id);
            if (category.ChildrensCategories != null)
                foreach (var childCategory in category.ChildrensCategories)
                {
                    TraverseCategories(childCategory, ids);
                }
        }
    }
}
