import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from 'src/app/models/shop-models/category.model';

@Injectable()
export class CategoriesService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(category: Category): Promise<Category> {
        return this._http.post<Category>(environment._shopPanelApiUrl + 'category', category,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<Category[]> {
        return this._http.get<Category[]>(environment._shopPanelApiUrl + 'category/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'category/' + id,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getOnlyChilds() {
        return this._http.get<Category[]>(environment._shopPanelApiUrl + 'category/get-childrens',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async edit(category: Category): Promise<Category> {
        return this._http.patch<Category>(environment._shopPanelApiUrl + 'category', category,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}
