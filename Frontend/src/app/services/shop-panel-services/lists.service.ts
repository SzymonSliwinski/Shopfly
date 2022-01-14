import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ListsService {
    constructor(private _http: HttpClient) { }

    public async add(homeList: HomeList): Promise<HomeList> {
        return this._http.post<HomeList>(environment._shopPanelApiUrl + 'home-lists', homeList).toPromise()
    }

    public async getAll(): Promise<HomeList[]> {
        return this._http.get<HomeList[]>(environment._shopPanelApiUrl + 'home-lists/get-all').toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'home-lists/' + id).toPromise()
    }

    public async edit(homeList: HomeList): Promise<HomeList> {
        return this._http.patch<HomeList>(environment._shopPanelApiUrl + 'home-lists', homeList).toPromise()
    }

}
