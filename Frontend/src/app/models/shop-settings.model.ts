export enum SortOption {
    Comments,
    Popularity,
    Price,
    AddDate,
    Alphabetic
}

export function SortOptionToString(sortOption: SortOption): string {
    switch (sortOption) {
        case SortOption.Comments: return 'Comments';
        case SortOption.Popularity: return 'Popularity';
        case SortOption.Price: return 'Price';
        case SortOption.AddDate: return 'AddDate';
        case SortOption.Alphabetic: return 'Alphabetic';
    }
}

export function GetAllSortOptionsAsStrings(): string[] {
    return [
        'Comments',
        'Popularity',
        'Price',
        'AddDate',
        'Alphabetic'
    ];
}

export function SortOptionToEnum(sortOption: string): SortOption | void {
    switch (sortOption) {
        case 'Comments': return SortOption.Comments;
        case 'Popularity': return SortOption.Popularity;
        case 'Price': return SortOption.Price;
        case 'AddDate': return SortOption.AddDate;
        case 'Alphabetic': return SortOption.Alphabetic;
    }
}

export interface ShopSettings {
    shopName: string;
    allowGuestsForShopping: boolean;
    howLongDefinedAsNew: number;
    productsPerPage: number;
    displayProductQuantity: boolean;
    shopLogoPath: string;
    faviconPath: string;
    maxPhotoSize: number;
    defaultSortBy: SortOption;
    importFileSeparator: string;
    multipleValuesInFileSeparator: string;
    shopEmail: string;
    shopPhone: string;
    shopNip: string;
    shopAddress: string;


}