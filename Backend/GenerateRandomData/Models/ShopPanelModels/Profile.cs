using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopPanelModels
{
    public class Profile
    {
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
        public bool HasAccessToOrders { get; set; }
        public bool HasAccessToImports { get; set; }
        public bool HasAccessToProducts { get; set; }
        public bool HasAccessToCustomers { get; set; }
        public bool HasAccessToCharts { get; set; }
        public bool HasAccessToSettings { get; set; }
        public bool HasAccessToApi { get; set; }
        public bool HasAccessToEmployees { get; set; }
    }
}
