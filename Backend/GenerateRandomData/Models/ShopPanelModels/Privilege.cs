using System.Collections.Generic;

namespace GenerateRandomData.Models.ShopPanelModels
{
    public class Privilege
    {
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public List<ProfilesPrivileges> ProfilesPrivileges { get; set; }
    }
}
