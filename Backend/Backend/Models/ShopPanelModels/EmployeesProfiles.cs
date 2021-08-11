namespace Backend.Models.ShopPanelModels
{
    public class EmployeesProfiles
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; } 
    }
}
