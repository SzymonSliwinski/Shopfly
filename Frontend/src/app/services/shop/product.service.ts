import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FilterDto } from 'src/app/components/shop/products-page/products-page.component';
import { Product } from 'src/app/models/shop-models/product.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductsService {
    constructor(private _http: HttpClient) { }

    public async getByAllRelatedWithCategory(filterDto: FilterDto, page: string) {
        return this._http.post<Product[]>(environment._shopApiUrl + `shop/product/by-filter/page/${page}`, filterDto).toPromise()
    }

    public async getCountByCategory(filterDto: FilterDto,): Promise<number> {
        return this._http.post<number>(environment._shopApiUrl + `shop/product/by-filter`, filterDto).toPromise()
    }

    public async getPhoto(productId: number): Promise<Blob | void> {
        return this._http.get(environment._shopApiUrl + `shop/product/photo/${productId}`,
            { responseType: 'blob' }).toPromise()
            .catch(() => {
            });
    }

    public async getDetails(productId: number): Promise<Product> {
        return this._http.get<Product>(environment._shopApiUrl + `shop/product/details/${productId}`).toPromise()
    }
}
