import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProfileService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(profile: Profile): Promise<Profile> {
        return this._http.post<Profile>(environment._shopPanelApiUrl + 'profile', profile,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<Profile[]> {
        return this._http.get<Profile[]>(environment._shopPanelApiUrl + 'profile/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'profile/' + id,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async edit(employee: Profile): Promise<Profile> {
        return this._http.patch<Profile>(environment._shopPanelApiUrl + 'profile', employee,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getProfilesForEmployee(employeeId: number): Promise<Profile[]> {
        return this._http.get<Profile[]>(environment._shopPanelApiUrl + `profile/get-profiles-for-employee/${employeeId}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}
