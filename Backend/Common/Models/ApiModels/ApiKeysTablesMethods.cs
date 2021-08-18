
namespace Common.Models.ApiModels
{
    public class ApiKeysTablesMethods
    {
        public int ApiAccessKeyId { get; set; }
        public ApiAccessKey ApiAccessKey { get; set; }
        public int HttpMethodId { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
