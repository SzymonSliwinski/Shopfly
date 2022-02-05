import { Component, OnInit } from '@angular/core';
import { ShopSettingsService } from './services/shop-settings.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Frontend';
  favIcon: HTMLLinkElement = document.querySelector('#appIcon')!;

  constructor(
    private readonly _shopSettingsService: ShopSettingsService
  ) { }

  async ngOnInit(): Promise<void> {
    console.log(this.favIcon)
    const x = await this._shopSettingsService.getSettings();
    if (x.faviconPath)
      this.favIcon.href = `assets/settings/${x.faviconPath}`;
  }
}
