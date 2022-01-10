import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ApiService {
    constructor(private _http: HttpClient) { }

    public async add(apiAccessKey: ApiAccessKey): Promise<ApiAccessKey> {
        return this._http.post<ApiAccessKey>(environment._shopPanelApiUrl + 'api', apiAccessKey).toPromise()
    }

    public async getAll(): Promise<ApiAccessKey[]> {
        return this._http.get<ApiAccessKey[]>(environment._shopPanelApiUrl + 'api').toPromise()
    }

    public async doesKeyExist(key: string): Promise<boolean> {
        return this._http.get<boolean>(environment._shopPanelApiUrl + `api/does-key-exist/${key}`).toPromise()
    }

    public async remove(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + `api/${id}`).toPromise()
    }

}
