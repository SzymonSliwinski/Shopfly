import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class ShopSettingsService<T> {
    constructor(private _http: HttpClient) { }
    public async delete(id: number, url: string): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + url,).toPromise()
    }
    // public async update(model: T): Promise<T> {
    //     return this._http.patch<T>(environment._shopPanelApiUrl + 'shop-settings', shopSettings).toPromise()
    // }

    // public async setPhoto(file: File): Promise<string> {
    //     const formData = new FormData();
    //     formData.append('file', file, file.name);
    //     const result = await this._http.post<SettingsPhotoDto>(environment._shopPanelApiUrl + 'shop-settings/settings-photo', formData).toPromise();
    //     return result.fileName;
    // }
}
