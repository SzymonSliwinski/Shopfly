using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ApiModels
{
    public class ApiAccessKey : EntityBase
    {
        public DateTime CreateDate { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
        public List<ApiKeysTablesMethods> ApiKeysTablesMethods { get; set; }
    }
}
