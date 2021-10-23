namespace GenerateRandomData.Models.ShopPanelModels
{
    public class ProfilesPrivileges
    {
        public int ProfileId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Profile Profile { get; set; }
        public int PrivilegeId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public Privilege Privilege { get; set; }
    }
}
