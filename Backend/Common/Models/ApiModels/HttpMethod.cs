﻿using System.Collections.Generic;

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
        public List<ApiKeysTablesMethods> ApiKeysTablesMethods { get; set; }

        public HttpMethodsTypes Type { get; set; }
    }
}
