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
                            var employeeList = new FileRepository<Employee>(new List<Employee>());
                            await employeeList.ParseModel(file, TableType.employees);
                            //await _context.AddRangeAsync(employeeList);

                            //foreach (var employee in employeeList)
                            //{
                            //    _context.Employees.Add(employee);
                            //}


                            return Ok();
                            break;
                    }

                    return Ok();
                    //FileRepository<>
                    //return await FileRepository.ParseModel(file, tableTypes);
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
