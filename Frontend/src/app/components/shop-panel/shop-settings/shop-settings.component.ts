import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SortOptionToString, GetAllSortOptionsAsStrings, SortOptionToEnum, ShopSettings, SortOption } from 'src/app/models/shop-settings.model';
import { ShopSettingsService } from 'src/app/services/shop-settings.service';

@Component({
  selector: 'app-shop-settings',
  templateUrl: './shop-settings.component.html',
  styleUrls: ['./shop-settings.component.scss']
})
export class ShopSettingsComponent implements OnInit {
  public shopSettings!: ShopSettings;
  private shopSettingsCopy!: ShopSettings;
  public isLoaded = false;
  constructor(
    private readonly _shopSettingsService: ShopSettingsService,
    private _snackBar: MatSnackBar
  ) { }

  async ngOnInit(): Promise<void> {
    this.shopSettings = await this._shopSettingsService.getSettings();
    this.setCopyOfShopsettings();
    this.isLoaded = true;
  }

  private setCopyOfShopsettings(): void {
    this.shopSettingsCopy = JSON.parse(JSON.stringify(this.shopSettings))
  }

  public async importFile(event: any, fileType: 'logo' | 'favicon'): Promise<void> {
    if (event.target.files.length !== 1)
      return;
    const file: File = event.target.files[0];
    if (file) {
      const path =
        await this._shopSettingsService.setPhoto(file);
      setTimeout(() => {
        if (fileType === 'logo')
          this.shopSettings.shopLogoPath = path;
        else
          this.shopSettings.faviconPath = path;
      }, 2000);

    }
    event.target.value = '';
  }

  public removePhoto(fileType: 'logo' | 'favicon') {
    if (fileType === 'logo')
      this.shopSettings.shopLogoPath = '';
    else
      this.shopSettings.faviconPath = '';

    //to do remove file in assets
  }

  public async onSaveClick(): Promise<void> {
    if (JSON.stringify(this.shopSettingsCopy) === JSON.stringify(this.shopSettings))
      return;
    await this._shopSettingsService.update(this.shopSettings);
    this._snackBar.open("Saved!", "OK", { duration: 5000 });
    this.setCopyOfShopsettings();
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
