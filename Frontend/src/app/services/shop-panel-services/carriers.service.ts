import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CarriersService {
    constructor(private _http: HttpClient) { }

    public async add(carrier: Carrier): Promise<Employee> {
        return this._http.post<Employee>(environment._shopPanelApiUrl + 'carrier', carrier).toPromise()
    }

    public async getAll(): Promise<Carrier[]> {
        return this._http.get<Carrier[]>(environment._shopPanelApiUrl + 'carrier/get-all').toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'carrier/' + id).toPromise()
    }

    public async edit(carrier: Carrier): Promise<Carrier> {
        return this._http.patch<Carrier>(environment._shopPanelApiUrl + 'carrier', carrier).toPromise()
    }
}
