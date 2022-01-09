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



}
