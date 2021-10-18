using System;

namespace GenerateRandomData.Models.ApiModels
{
    public class ApiAccessKey
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Key { get; set; }
    }
}
