import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Status } from 'src/app/models/shop-models/status.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class StatusService {
    constructor(private _http: HttpClient) { }

    public async add(status: Status): Promise<Status> {
        return this._http.post<Status>(environment._shopPanelApiUrl + 'status', status).toPromise()
    }

    public async getAll(): Promise<Status[]> {
        return this._http.get<Status[]>(environment._shopPanelApiUrl + 'status/get-all').toPromise()
    }

}
