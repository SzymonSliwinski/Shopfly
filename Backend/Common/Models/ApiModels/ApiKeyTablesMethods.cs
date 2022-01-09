
using System.Text.Json.Serialization;

namespace Common.Models.ApiModels
{
    public enum TableType
    {
        employees,
        employeesProfiles,
        profiles,
        customers,
        statuses,
        orders,
        ordersProducts,
        customrFavouritesProducts,
        ratings,
        comments,
        tags,
        productTags,
        products,
        productsPayments,
        paymentTypes,
        carriers,
        productsCarriers,
        taxes,
        categories,
        productsVariants,
        productsVariantsPhotos,
        photos,
        productColors,
        productDiemensions
    }
    public enum HttpMethodType
    {
        post,
        get,
        patch,
        delete
    }
    public class ApiKeysTablesMethods : EntityBase
    {
        [JsonIgnore]
        public ApiAccessKey ApiAccessKey { get; set; }
        public int ApiAccessKeyId { get; set; }
        public TableType Table { get; set; }
        public HttpMethodType HttpMethod { get; set; }
    }
}
