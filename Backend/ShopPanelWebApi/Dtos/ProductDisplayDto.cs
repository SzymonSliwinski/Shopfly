using Common.Models.ShopModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Dtos
{
    public class ProductDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float NettoPrice { get; set; }
        public float BruttoPrice { get; set; }
        public bool IsVisible { get; set; }
        public int Stock { get; set; }

        public ProductDisplayDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Category = product.Category.Name;
            NettoPrice = product.NettoPrice;
            BruttoPrice = product.BruttoPrice;
            IsVisible = product.IsVisible;
            Stock = product.Stock;
        }

    }
}
