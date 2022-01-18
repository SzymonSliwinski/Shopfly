using Common.Models.ShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Dtos
{
    public class OrderDisplayDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public float TotalValue { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public OrderDisplayDto(Order order)
        {
            Id = order.Id;
            CustomerName = order.Customer.Name + " " + order.Customer.Surname;
            TotalValue = order.PriceTotal;
            PaymentType = order.PaymentType.Name;
            Status = order.Status.Name;
            Date = order.Date;
        }
    }
}
