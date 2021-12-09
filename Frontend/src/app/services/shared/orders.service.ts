import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from 'src/app/models/shop-models/order.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class OrderService {
    constructor(private _http: HttpClient) { }

    public async update(order: Order): Promise<Order> {
        return this._http.patch<Order>(environment._shopPanelApiUrl + 'order', order).toPromise()
    }

    public async add(order: Order): Promise<Order> {
        return this._http.post<Order>(environment._shopPanelApiUrl + 'order', order).toPromise()
    }

    public async delete(orderId: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'order/' + orderId).toPromise()
    }

    public async getDetailed(orderId: number): Promise<Order> {
        return this._http.delete<Order>(environment._shopPanelApiUrl + 'order/' + orderId).toPromise()
    }
}
