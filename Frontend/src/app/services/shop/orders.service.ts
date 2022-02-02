import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { Order } from 'src/app/models/shop-models/order.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class OrdersService {
    constructor(private _http: HttpClient) { }

    public async add(order: Order): Promise<void> {
        return this._http.post<void>(environment._shopApiUrl + 'shop/order', order).toPromise()
    }

    public async getUserOrders(): Promise<OrderDisplayDto[]> {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.get<OrderDisplayDto[]>(environment._shopApiUrl + `shop/order/get-user-orders/${userId}`).toPromise()
    }

    public async getAllProductsForOrder(orderId: number): Promise<ProductDisplayDto[]> {
        return this._http.get<ProductDisplayDto[]>(environment._shopApiUrl + `shop/order/get-all-for-order/${orderId}`).toPromise()
    }

    public async getFvForOrder(orderId: number): Promise<Blob> {
        return this._http.get(environment._shopApiUrl + `shop/order/fv/${orderId}`,
            { responseType: 'blob' }).toPromise()
    }
}
