import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Status } from 'src/app/models/shop-models/status.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class StatusService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(status: Status): Promise<Status> {
        return this._http.post<Status>(environment._shopPanelApiUrl + 'status', status,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<Status[]> {
        return this._http.get<Status[]>(environment._shopPanelApiUrl + 'status/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async changeStatusForOrder(orderId: number, statusId: number) {
        return this._http.get<void>(environment._shopPanelApiUrl + `status/set-status/${statusId}/for-order/${orderId}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}
