import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CarriersService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(carrier: Carrier): Promise<Employee> {
        return this._http.post<Employee>(environment._shopPanelApiUrl + 'carrier', carrier,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<Carrier[]> {
        return this._http.get<Carrier[]>(environment._shopPanelApiUrl + 'carrier/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'carrier/' + id,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async edit(carrier: Carrier): Promise<Carrier> {
        return this._http.patch<Carrier>(environment._shopPanelApiUrl + 'carrier', carrier,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }
}
