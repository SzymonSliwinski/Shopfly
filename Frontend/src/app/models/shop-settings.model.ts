export enum SortOption {
    Comments,
    Popularity,
    Price,
    AddDate,
    Alphabetic
}

export function DefaultSortOptionToString(sortOption: SortOption): string {
    switch (sortOption) {
        case SortOption.Comments: return 'Comments';
        case SortOption.Popularity: return 'Popularity';
        case SortOption.Price: return 'Price';
        case SortOption.AddDate: return 'AddDate';
        case SortOption.Alphabetic: return 'Alphabetic';
    }
}

export interface ShopSettings {
    isCatalogMode: boolean;
    allowGuestsForShopping: boolean;
    howLongDefinedAsNew: number;
    productsPerPage: number;
    displayProductQuantity: boolean;
    shopLogoPath: string;
    faviconPath: string;
    maxPhotoSize: number;
    defaultSortBy: SortOption;
    importFileSeparator: string & { length: 1 };
    multipleValuesInFileSeparator: string & { length: 1 };

}