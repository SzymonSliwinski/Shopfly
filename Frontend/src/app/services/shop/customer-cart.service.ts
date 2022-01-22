import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomerCartService {
    constructor(private _http: HttpClient) { }

    public async getAllForLoggedUser(): Promise<CustomerCart[]> {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.get<CustomerCart[]>(environment._shopApiUrl + `shop/customer-cart/get-all/for-user/${userId}`).toPromise()
    }

    public async clear() {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.delete<void>(environment._shopApiUrl + `shop/customer-cart/clear-user-cart/${userId}`).toPromise()
    }

    public async removeProduct(productId: number) {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.delete<void>(environment._shopApiUrl + `shop/customer-cart/remove/${productId}/${userId}`).toPromise()
    }

    public async add(productId: number): Promise<void> {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        const payload = {
            customerId: userId,
            productId: productId
        } as CustomerCart
        return this._http.post<void>(environment._shopApiUrl + 'shop/customer-cart', payload).toPromise()
    }


}
