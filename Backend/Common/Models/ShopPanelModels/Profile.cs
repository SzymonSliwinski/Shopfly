using System.Collections.Generic;

namespace Common.Models.ShopPanelModels
{
    public class Profile
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
