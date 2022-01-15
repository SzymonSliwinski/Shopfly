import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ListsService {
    constructor(private _http: HttpClient) { }

    public async getAll(): Promise<HomeList[]> {
        return this._http.get<HomeList[]>(environment._shopApiUrl + 'shop/home-lists/get-all').toPromise()
    }


}
