import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ShopSettings } from '../models/shop-settings.model';

interface SettingsPhotoDto {
    fileName: string;
}

@Injectable()
export class ShopSettingsService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async getSettings(): Promise<ShopSettings> {
        return this._http.get<ShopSettings>(environment._shopPanelApiUrl + 'shop-settings',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async update(shopSettings: ShopSettings): Promise<ShopSettings> {
        return this._http.patch<ShopSettings>(environment._shopPanelApiUrl + 'shop-settings', shopSettings,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async setPhoto(file: File): Promise<string> {
        const formData = new FormData();
        formData.append('file', file, file.name);
        const result = await this._http.post<SettingsPhotoDto>(environment._shopPanelApiUrl + 'shop-settings/settings-photo', formData,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise();
        return result.fileName;
    }
}
