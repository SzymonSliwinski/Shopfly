import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/shop-models/product.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductsService {
    constructor(private _http: HttpClient) { }

    public async getByAllRelatedWithCategory(categoryName: string) {
        return this._http.get<Product[]>(environment._shopApiUrl + `shop/product/get-related-with/${categoryName}`).toPromise()
    }
}
