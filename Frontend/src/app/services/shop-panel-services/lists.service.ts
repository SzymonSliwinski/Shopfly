import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ListsService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(homeList: HomeList): Promise<HomeList> {
        return this._http.post<HomeList>(environment._shopPanelApiUrl + 'home-lists', homeList,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<HomeList[]> {
        return this._http.get<HomeList[]>(environment._shopPanelApiUrl + 'home-lists/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'home-lists/' + id,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async edit(homeList: HomeList): Promise<HomeList> {
        return this._http.patch<HomeList>(environment._shopPanelApiUrl + 'home-lists', homeList,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}
