import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'src/app/models/shop-models/product.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductsService {
    constructor(private _http: HttpClient) { }

    public async getByAllRelatedWithCategory(categoryName: string, page: string) {
        return this._http.get<Product[]>(environment._shopApiUrl + `shop/product/get-related-with/${categoryName}/page/${page}`).toPromise()
    }

    public async getCountByCategory(categoryName: string,): Promise<number> {
        return this._http.get<number>(environment._shopApiUrl + `shop/product/get-count-by-category/${categoryName}`).toPromise()
    }

    public async getPhoto(productId: number): Promise<Blob> {
        return this._http.get(environment._shopApiUrl + `shop/product/photo/${productId}`,
            { responseType: 'blob' }).toPromise();
    }

    public async getDetails(productId: number): Promise<Product> {
        return this._http.get<Product>(environment._shopApiUrl + `shop/product/details/${productId}`).toPromise()
    }
}
