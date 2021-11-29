namespace Common.Models
{
    public class ShopSettings : EntityBase
    {
        public enum SortOption
        {
            Comments,
            Popularity,
            Price,
            AddDate,
            Alphabetic
        }

        // general
        public string ShopName { get; set; }
        public bool AllowGuestsForShopping { get; set; }
        public short HowLongDefinedAsNew { get; set; }
        public short ProductsPerPage { get; set; }
        public bool DisplayProductQuantity { get; set; }
        public SortOption DefaultSortBy { get; set; }

        // photos
        public string ShopLogoPath { get; set; }
        public string FaviconLogoPath { get; set; }
        public short MaxPhotoSize { get; set; }
        // files
        public char ImportFileSeparator { get; set; }
        public char MultipleValuesInFileSeparator { get; set; }


    }
}
