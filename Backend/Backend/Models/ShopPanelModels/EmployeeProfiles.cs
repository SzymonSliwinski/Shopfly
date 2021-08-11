namespace Backend.Models.ShopPanelModels
{
    public class EmployeeProfiles
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; } 
    }
}
