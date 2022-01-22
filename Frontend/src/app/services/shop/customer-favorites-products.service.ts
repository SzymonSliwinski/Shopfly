import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { CustomerFavouritesProducts } from 'src/app/models/shop-models/customer-favourites-products.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomerFavoritesProductsService {
    constructor(private _http: HttpClient) { }

    public async getAllForLoggedUser(): Promise<CustomerCart[]> {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        return this._http.get<CustomerCart[]>(environment._shopApiUrl + `shop/customer-favorites/get-all/for-user/${userId}`).toPromise()
    }

    public async add(productId: number): Promise<void> {
        const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
        const payload = {
            customerId: userId,
            productId: productId
        } as CustomerFavouritesProducts
        return this._http.post<void>(environment._shopApiUrl + 'shop/customer-favorites', payload).toPromise()
    }


}
