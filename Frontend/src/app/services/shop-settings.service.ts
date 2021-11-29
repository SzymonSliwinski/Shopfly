import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ShopSettings } from '../models/shop-settings.model';

@Injectable()
export class ShopSettingsService {
    constructor(private _http: HttpClient) { }

    public async getSettings(): Promise<ShopSettings> {
        return this._http.get<ShopSettings>(environment._shopPanelApiUrl + 'shop-settings').toPromise()
    }

    public async update(shopSettings: ShopSettings): Promise<ShopSettings> {
        return this._http.post<ShopSettings>(environment._shopPanelApiUrl + 'shop-settings', shopSettings).toPromise()
    }

    public async setFavicon(file: File): Promise<ShopSettings> {
        const formData = new FormData();
        formData.append('file', file, file.name);
        return this._http.post<ShopSettings>(environment._shopPanelApiUrl + 'shop-settings/favicon', formData).toPromise()
    }
}
