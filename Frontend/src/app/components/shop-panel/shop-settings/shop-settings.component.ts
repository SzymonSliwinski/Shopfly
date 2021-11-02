import { Component, OnInit } from '@angular/core';
import { SortOptionToString, GetAllSortOptionsAsStrings, SortOptionToEnum, ShopSettings, SortOption } from 'src/app/models/shop-settings.model';

@Component({
  selector: 'app-shop-settings',
  templateUrl: './shop-settings.component.html',
  styleUrls: ['./shop-settings.component.scss']
})
export class ShopSettingsComponent implements OnInit {
  public shopSettings!: ShopSettings;
  constructor() { }

  ngOnInit(): void {
    this.shopSettings = {
      isCatalogMode: false,
      allowGuestsForShopping: false,
      howLongDefinedAsNew: 353,
      productsPerPage: 30,
      displayProductQuantity: true,
      defaultSortBy: SortOption.Alphabetic,
      shopLogoPath: '',
      faviconPath: '',
      maxPhotoSize: 321,
      importFileSeparator: '-',
      multipleValuesInFileSeparator: ';',
    }
  }

  public sortOptionToString(optionEnum: SortOption): string {
    return SortOptionToString(optionEnum);
  }

  public sortOptionToEnum(optionString: string): SortOption {
    return SortOptionToEnum(optionString)!;
  }

  public getSortOptionsAsStrings(): string[] {
    return GetAllSortOptionsAsStrings();
  }
}
