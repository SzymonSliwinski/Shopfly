import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomerCartService {
    constructor(private _http: HttpClient) { }

    public async getAllForLoggedUser(): Promise<CustomerCart[]> {
        console.log(sessionStorage.getItem(environment._shopStorageKey))
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        console.log(userId);
        return this._http.get<CustomerCart[]>(environment._shopApiUrl + `shop/customer-cart/get-all/for-user/${userId}`).toPromise()
    }

    public async add(productId: number): Promise<void> {
        console.log(sessionStorage.getItem(environment._shopStorageKey))
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        const payload = {
            customerId: userId,
            productId: productId
        } as CustomerCart
        console.log(userId);
        return this._http.post<void>(environment._shopApiUrl + 'shop/customer-cart', payload).toPromise()
    }


}
