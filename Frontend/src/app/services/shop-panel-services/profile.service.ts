import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProfileService {
    constructor(private _http: HttpClient) { }

    public async add(profile: Profile): Promise<Profile> {
        return this._http.post<Profile>(environment._shopPanelApiUrl + 'profile', profile).toPromise()
    }

    public async getAll(): Promise<Profile[]> {
        return this._http.get<Profile[]>(environment._shopPanelApiUrl + 'profile/get-all').toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'profile/' + id).toPromise()
    }

    public async edit(employee: Profile): Promise<Profile> {
        return this._http.patch<Profile>(environment._shopPanelApiUrl + 'profile', employee).toPromise()
    }

}
