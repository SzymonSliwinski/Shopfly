using Common.Models.ApiModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Common;
using Common.Models;
using Common.Models.ShopPanelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopPanelWebApi.Repositories
{
    public class FileRepository<T> where T : EntityBase
    {
        private readonly List<T> listOfObjects;
        public FileRepository(List<T> _list)
        {
            listOfObjects = _list;
        }

        public async Task<string> ReadFile(IFormFile file)
        {
            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public async Task<List<T>> ParseModel(IFormFile file, TableType tableType)
        {
            var fileContent = ReadFile(file);
            var parseContent = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(fileContent.Result);

            switch (tableType)
            {
                case TableType.employees:
                    //var parseContentEmployee = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(fileContent.Result);

                    //var modelsToAdd = parseContentEmployee;
                    //foreach (var employee in modelsToAdd)
                    //{
                    //    _context.Employees.Add(employee);
                    //}

                    return parseContent;
                    break;

                case TableType.employeesProfiles:
                    //var parseContentEmployeesProfiles = Newtonsoft.Json.JsonConvert.DeserializeObject<EmployeesProfiles>(fileContent.Result);

                    //var modelsToAdd = parseContent;

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

            return parseContent;
        }
    }
}
