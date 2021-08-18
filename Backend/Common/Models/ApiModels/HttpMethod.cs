using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Models.ApiModels
{
    public enum HttpMethodsTypes
    {
        post,
        get,
        patch,
        delete
    }

    public class HttpMethod
    {
        public int Id { get; set; }
        public HttpMethodsTypes Type { get; set; }
    }
}
