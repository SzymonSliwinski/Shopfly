using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common;
using Common.Models.ApiModels;
using Common.Models.ShopModels;
using Common.Services;
using OpenWebApi.Filters;

namespace OpenWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly AppDbContext _photoService;
        public PhotoController(AppDbContext context)
        {
            _photoService = context;
        }

        [KeyAuthenticationFilter(Table = TableType.photos, Method = HttpMethodType.get)]
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Photo>> GetById(int id)
        {
            var service = new CrudService<Photo>(_photoService);
            var photo = await service.GetById(id);

            return Ok(await service.GetById(photo.Id));
        }

        [KeyAuthenticationFilter(Table = TableType.photos, Method = HttpMethodType.get)]
        [HttpGet("get-all")]
        public async Task<ActionResult<Photo>> GetAll()
        {
            var service = new CrudService<Photo>(_photoService);
            return Ok(await service.GetAll());
        }

        [KeyAuthenticationFilter(Table = TableType.photos, Method = HttpMethodType.delete)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var service = new CrudService<Photo>(_photoService);
            await service.Delete(id);

            return Ok();
        }

        [KeyAuthenticationFilter(Table = TableType.photos, Method = HttpMethodType.post)]
        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromBody] Photo photo)
        {
            var service = new CrudService<Photo>(_photoService);

            photo.Path = photo.Path.Trim();

            return Ok(await service.Insert(photo));
        }

        [KeyAuthenticationFilter(Table = TableType.photos, Method = HttpMethodType.patch)]
        [HttpPatch]
        public async Task<ActionResult<Photo>> Update([FromBody] Photo updatedPhoto)
        {
            var service = new CrudService<Photo>(_photoService);
            var oldPhoto = await service.GetById(updatedPhoto.Id);

            oldPhoto.IsCover = updatedPhoto.IsCover;
            oldPhoto.Path = updatedPhoto.Path.Trim();

            return Ok(await service.Update(oldPhoto));
        }
    }
}
