using System.Collections.Generic;
using Common.Models.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Models.ShopPanelModels;
using ShopPanelWebApi.Repositories;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ImportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("table-type/{tableTypes}")]
        public async Task<ActionResult> GetExtension(IFormFile file, TableType tableTypes)
        {
            if (file.Length > 0)
            {
                var fileExtension = file.FileName.Split(".").Last();

                if (fileExtension == "json")
                {
                    switch (tableTypes)
                    {
                        case TableType.employees:
                            var employeeRepository = new FileRepository<Employee>(new List<Employee>());
                            var employeeList = await employeeRepository.ParseModel(file, TableType.employees);
                            await _context.AddRangeAsync(employeeList);

                            await _context.SaveChangesAsync();
                            return Ok();
                            break;

                        case TableType.employeesProfiles:

                            break;

                        case TableType.profiles:

                            break;

                        case TableType.profilesPrivileges:

                            break;

                        case TableType.privileges:

                            break;

                        case TableType.customers:

                            break;

                        case TableType.statuses:

                            break;

                        case TableType.orders:

                            break;

                        case TableType.ordersProducts:

                            break;

                        case TableType.customrFavouritesProducts:

                            break;

                        case TableType.ratings:

                            break;

                        case TableType.comments:

                            break;

                        case TableType.tags:

                            break;

                        case TableType.productTags:

                            break;

                        case TableType.products:

                            break;

                        case TableType.productsPayments:

                            break;

                        case TableType.paymentTypes:

                            break;

                        case TableType.carriers:

                            break;

                        case TableType.productsCarriers:

                            break;

                        case TableType.taxes:

                            break;

                        case TableType.categories:

                            break;

                        case TableType.productsVariants:

                            break;

                        case TableType.productsVariantsPhotos:

                            break;

                        case TableType.photos:

                            break;

                        case TableType.productColors:

                            break;

                        case TableType.productDiemensions:

                            break;

                        default:
                            new UnsupportedMediaTypeResult();
                            break;
                    }

                    return Ok();
                }
                else
                    return new UnsupportedMediaTypeResult();
            }
            else
                return new UnsupportedMediaTypeResult();
        }

        //public async List<T> 
    }
}
