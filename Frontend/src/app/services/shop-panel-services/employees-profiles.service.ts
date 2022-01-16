import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeesProfiles } from 'src/app/models/shop-panel-models/employees-profiles';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmployeesProfilesService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async add(profile: EmployeesProfiles): Promise<EmployeesProfiles> {
        console.log(profile);
        return this._http.post<EmployeesProfiles>(environment._shopPanelApiUrl + 'employees-profiles/add-single', profile,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getAll(): Promise<EmployeesProfiles[]> {
        return this._http.get<EmployeesProfiles[]>(environment._shopPanelApiUrl + 'employees-profiles/get-all',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async delete(profile: EmployeesProfiles): Promise<void> {
        return this._http.post<void>(environment._shopPanelApiUrl + 'employees-profiles/delete', profile,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }
}
