import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from 'src/app/models/shop-models/customer.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomersService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async getAll(): Promise<Customer[]> {
        return this._http.get<Customer[]>(environment._shopPanelApiUrl + 'customer/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }
}
