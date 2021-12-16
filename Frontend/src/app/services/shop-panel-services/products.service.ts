import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { Product } from 'src/app/models/shop-models/product.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProductsService {
    constructor(private _http: HttpClient) { }

    public async add(product: Product): Promise<Product> {
        return this._http.post<Product>(environment._shopPanelApiUrl + 'product', product).toPromise()
    }

    public async getAll(): Promise<Product[]> {
        return this._http.get<Product[]>(environment._shopPanelApiUrl + 'get-all').toPromise()
    }

    public async getForTable(): Promise<ProductDisplayDto[]> {
        return this._http.get<ProductDisplayDto[]>(environment._shopPanelApiUrl + 'product/get-all-as-dtos').toPromise()
    }
}
