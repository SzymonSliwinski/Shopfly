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
    public class FileRepository<T>
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

            return parseContent;
        }
    }
}
