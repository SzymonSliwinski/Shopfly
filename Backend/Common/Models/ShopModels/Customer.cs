using System;
using System.Collections.Generic;

namespace Common.Models.ShopModels
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsNewsletterSubscribed { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Password { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<CustomerFavouritesProducts> CustomerFavouritesProducts { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsActive { get; set; }

    }
}
