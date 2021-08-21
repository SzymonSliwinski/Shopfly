using System;
using System.Collections.Generic;

namespace Common.Models.ApiModels
{
    public class ApiAccessKey
    {
        public int Id { get; set; }
        public List<ApiKeysTablesMethods> ApiKeysTablesMethods { get; set; }
        public DateTime CreateDate { get; set; }
        public string Key { get; set; }
    }
}
