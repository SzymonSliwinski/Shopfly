import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CarriersService {
    constructor(private _http: HttpClient) { }

    public async getAll(): Promise<Carrier[]> {
        return this._http.get<Carrier[]>(environment._shopApiUrl + 'shop/carrier/get-all').toPromise()
    }
}
