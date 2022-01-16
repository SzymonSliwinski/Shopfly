import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class OrdersService {
    constructor(private _http: HttpClient) { }

    public async add(order: Order): Promise<void> {
        return this._http.post<void>(environment._shopApiUrl + 'shop/order', order).toPromise()
    }
}
