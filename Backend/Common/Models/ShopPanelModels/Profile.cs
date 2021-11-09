using System.Collections.Generic;

namespace Common.Models.ShopPanelModels
{
    public class Profile : EntityBase
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
