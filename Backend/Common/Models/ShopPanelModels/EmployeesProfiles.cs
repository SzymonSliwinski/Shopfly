using System.Text.Json.Serialization;

namespace Common.Models.ShopPanelModels
{
    public class EmployeesProfiles : ManyToManyEntityBase
    {
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public int ProfileId { get; set; }
        [JsonIgnore]
        public Profile Profile { get; set; }
    }
}
