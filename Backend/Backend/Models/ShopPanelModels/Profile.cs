using System.Collections.Generic;

namespace Backend.Models.ShopPanelModels
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
