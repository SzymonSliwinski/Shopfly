
namespace Common.Models.ApiModels
{
    public enum TableType
    {
        employees = 1,
        employeesProfiles = 2,
        profiles = 3,
        profilesPrivileges = 4,
        privileges = 5,
        customers = 6,
        statuses = 7,
        orders = 8,
        ordersProducts = 9,
        customrFavouritesProducts = 10,
        ratings = 11,
        comments = 12,
        tags = 13,
        productTags = 14,
        products = 15,
        productsPayments = 16,
        paymentTypes = 17,
        carriers = 18,
        productsCarriers = 19,
        taxes = 20,
        categories = 21,
        productsVariants = 22,
        productsVariantsPhotos = 23,
        photos = 24,
        productColors = 25,
        productDiemensions = 26
    }
    public enum HttpMethodType
    {
        post = 1,
        get = 2,
        patch = 3,
        delete = 4
    }
    public class ApiKeysTablesMethods
    {
        public int Id { get; set; }
        public ApiAccessKey ApiAccessKey { get; set; }
        public int ApiAccessKeyId { get; set; }
        public TableType Table { get; set; }
        public HttpMethodType HttpMethodId { get; set; }
    }
}
