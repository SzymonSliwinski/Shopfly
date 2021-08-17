using System;
using System.Collections.Generic;

namespace Backend.Models.ShopModels
{
    public class Order
    {
        // Order properties:
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float PriceTotal { get; set; }
        public DateTime Date { get; set; }
        public string AdditionalDescription { get; set; }
        public List<OrdersProducts> OrdersProducts { get; set; }

        // Delivery:
        public string DeliveryAddressStreet { get; set; }
        public string DeliveryAddressPostal { get; set; }
        public string DeliveryAddressCity { get; set; }
        public string DeliveryAddressCountry { get; set; }

        // Billing:
        public string BillingAddressStreet { get; set; }
        public string BillingAddressPostal { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressCountry { get; set; }

        // Additional:
        public string Nip { get; set; }
        public string CompanyName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}
