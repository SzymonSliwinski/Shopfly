namespace Common.Models.ShopPanelModels
{
    public class EmployeesProfiles
    {
        public int EmployeeId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Employee Employee { get; set; }
        public int ProfileId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Profile Profile { get; set; }
    }
}
