import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChangePasswordDto } from 'src/app/dto/change-password.dto';
import { environment } from 'src/environments/environment';
import { Category } from 'src/app/models/shop-models/category.model';

@Injectable()
export class CategoriesService {
    constructor(private _http: HttpClient) { }

    public async add(category: Category): Promise<Category> {
        return this._http.post<Category>(environment._shopPanelApiUrl + 'category', category).toPromise()
    }

    public async getAll(): Promise<Category[]> {
        return this._http.get<Category[]>(environment._shopPanelApiUrl + 'category/get-all').toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'category/' + id).toPromise()
    }

    public async edit(category: Category): Promise<Category> {
        return this._http.patch<Category>(environment._shopPanelApiUrl + 'category', category).toPromise()
    }

}
