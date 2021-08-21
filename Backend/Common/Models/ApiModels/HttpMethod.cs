﻿using System.Collections.Generic;

namespace Common.Models.ApiModels
{
    public enum HttpMethodType
    {
        post = 1,
        get = 2,
        patch = 3,
        delete = 4
    }

    public class HttpMethod
    {
        public int Id { get; set; }
        public List<ApiKeysTablesMethods> ApiKeysTablesMethods { get; set; }

        public HttpMethodType Type { get; set; }
    }
}
