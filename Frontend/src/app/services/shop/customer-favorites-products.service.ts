import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { CustomerFavouritesProducts } from 'src/app/models/shop-models/customer-favourites-products.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomerFavoritesProductsService {
    constructor(
        private _http: HttpClient,
        private _router: Router) { }

    public async getAllForLoggedUser(): Promise<CustomerCart[]> {
        if (!JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!))
            this._router.navigate(['sign-in']);

        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.get<CustomerCart[]>(environment._shopApiUrl + `shop/customer-favorites/get-all/for-user/${userId}`).toPromise()
    }

    public async add(productId: number): Promise<void> {
        if (!JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!))
            this._router.navigate(['sign-in']);
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        const payload = {
            customerId: userId,
            productId: productId
        } as CustomerFavouritesProducts
        return this._http.post<void>(environment._shopApiUrl + 'shop/customer-favorites', payload).toPromise()
    }


}
