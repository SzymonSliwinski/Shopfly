import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from 'src/app/models/shop-models/category.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CategoryService {
    constructor(private _http: HttpClient) { }

    public async getAll(): Promise<Category[]> {
        return this._http.get<Category[]>(environment._shopApiUrl + 'shop/category/get-all').toPromise()
    }
}
