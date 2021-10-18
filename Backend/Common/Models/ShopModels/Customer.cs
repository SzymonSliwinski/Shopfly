using System;
using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Customer
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsNewsletterSubscribed { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        // todo default language table (defaultLanguageId)
        public string Password { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Comment> Comments { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Rating> Ratings { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
