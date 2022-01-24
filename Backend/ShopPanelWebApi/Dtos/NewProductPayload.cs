using Common.Models.ShopModels;
using Microsoft.AspNetCore.Http;

namespace ShopPanelWebApi.Dtos
{
    public class NewProductPayload
    {
        public Product Product { get; set; }
        public IFormFile file { get; set; }
    }
}
