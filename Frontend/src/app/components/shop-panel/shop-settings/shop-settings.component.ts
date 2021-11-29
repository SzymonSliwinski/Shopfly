import { Component, OnInit } from '@angular/core';
import { SortOptionToString, GetAllSortOptionsAsStrings, SortOptionToEnum, ShopSettings, SortOption } from 'src/app/models/shop-settings.model';
import { ShopSettingsService } from 'src/app/services/shop-settings.service';

@Component({
  selector: 'app-shop-settings',
  templateUrl: './shop-settings.component.html',
  styleUrls: ['./shop-settings.component.scss']
})
export class ShopSettingsComponent implements OnInit {
  public shopSettings!: ShopSettings;
  constructor(
    private readonly _shopSettingsService: ShopSettingsService
  ) { }

  ngOnInit(): void {
    this.shopSettings = {
      shopName: 'Shopfly',
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

  async importFile(event: any, fileType: 'logo' | 'favicon'): Promise<void> {
    if (event.target.files.length !== 1)
      return;

    const file: File = event.target.files[0];
    if (file) {
      if (fileType === 'favicon')
        await this._shopSettingsService.setFavicon(file);
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
