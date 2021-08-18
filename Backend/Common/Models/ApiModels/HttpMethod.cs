using System.Collections.Generic;

namespace Common.Models.ApiModels
{
    public enum HttpMethodsType
    {
        post,
        get,
        patch,
        delete
    }

    public class HttpMethod
    {
        public int Id { get; set; }
        public List<ApiKeysTablesMethods> ApiKeysTablesMethods { get; set; }

        public HttpMethodsType Type { get; set; }
    }
}
