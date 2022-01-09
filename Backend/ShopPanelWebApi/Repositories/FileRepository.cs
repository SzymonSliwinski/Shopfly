using Common.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopPanelWebApi.Repositories
{
    public class FileRepository
    {
        public static void CheckFile(IFormFile file, TableType tableType, string extension)
        {
            switch (tableType)
            {
                case TableType.employees:
                    if (extension == ".json")
                    {
                        var parseContent = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(file.ToString());
                    }

                    if (extension == ".csv")
                    {

                    }
                    else
                        new UnsupportedMediaTypeResult();
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
        }

        //public static CheckTable()
        //{

        //}
        
    }
}
