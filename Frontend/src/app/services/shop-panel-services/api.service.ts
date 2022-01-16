import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(apiAccessKey: ApiAccessKey): Promise<ApiAccessKey> {
        return this._http.post<ApiAccessKey>(environment._shopPanelApiUrl + 'api', apiAccessKey,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async update(apiAccessKey: ApiAccessKey): Promise<void> {
        return this._http.patch<void>(environment._shopPanelApiUrl + 'api', apiAccessKey,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<ApiAccessKey[]> {
        return this._http.get<ApiAccessKey[]>(environment._shopPanelApiUrl + 'api',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async doesKeyExist(key: string): Promise<boolean> {
        return this._http.get<boolean>(environment._shopPanelApiUrl + `api/does-key-exist/${key}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getFullByKey(key: string): Promise<ApiAccessKey> {
        return this._http.get<ApiAccessKey>(environment._shopPanelApiUrl + `api/get-full-by-key/${key}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async remove(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + `api/${id}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}
