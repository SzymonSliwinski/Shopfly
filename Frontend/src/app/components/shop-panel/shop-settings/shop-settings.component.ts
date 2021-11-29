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

  async ngOnInit(): Promise<void> {
    this.shopSettings = await this._shopSettingsService.getSettings();
  }

  onLogoChange(value: any): void {
    console.log(value)

  }

  onFaviconChange(value: any): void {
    console.log(value)
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
