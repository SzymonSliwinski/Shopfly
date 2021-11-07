namespace Common.Models.ShopPanelModels
{
    public class ProfilesPrivileges : ManyToManyEntityBase
    {
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
    }
}
