using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopPanelWebApi.Dtos
{
    public class ViewDto
    {
        public int NewOrdersToday { get; set; }
        public int ActiveOrders { get; set; }
        public float OrdersTotalValue { get; set; }
        public float AverageOrderValue { get; set; }
        public List<OrderDisplayDto> OrderDisplayDto { get; set; }
    }
}
