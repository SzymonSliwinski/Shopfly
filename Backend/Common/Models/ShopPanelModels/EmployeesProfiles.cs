namespace Common.Models.ShopPanelModels
{
    public class EmployeesProfiles : ManyToManyEntityBase
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
