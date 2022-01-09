using Common.Models.ApiModels;
using Common.Utilieties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Controllers
{
    [Route("shop-panel/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        [HttpPost("table-type/{tableTypes}")]
        public async Task<ActionResult> GetExtension(IFormFile file, TableType tableTypes)
        {
            if (file.Length > 0)
            {
                var fileExtension = file.FileName.Split(".").Last();

                if (fileExtension == "json")
                {
                    // wywołanie parsowania?
                    // sprawdzenie, do jakiej tabeli ma to iść. na podstawie enuma.
                    // jeśli ktoś wrzuci zły plik, trzeba zrobić walidację pliku, czy ma dobre kolumny.

                    ShopPanelWebApi.Repositories.FileRepository.CheckFile(file, tableTypes, fileExtension);
                }
                else if (fileExtension == "csv")
                {
                    ShopPanelWebApi.Repositories.FileRepository.CheckFile(file, tableTypes, fileExtension);
                }
                else
                    return new UnsupportedMediaTypeResult();    // zwraca 415
            }
            else
                return new UnsupportedMediaTypeResult();

            return new UnsupportedMediaTypeResult();
        }
    }

}