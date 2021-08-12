using System.Collections.Generic;

namespace Backend.Models.ShopPanelModels
{
    public class Privilege
    {
        public int Id { get; set; }
        public string Name { get; set; }    // todo length of string
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
    }
}
