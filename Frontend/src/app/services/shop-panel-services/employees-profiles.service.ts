import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeesProfiles } from 'src/app/models/shop-panel-models/employees-profiles';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmployeesProfilesService {
    constructor(private _http: HttpClient) { }

    public async add(profile: EmployeesProfiles): Promise<EmployeesProfiles> {
        console.log(profile);
        return this._http.post<EmployeesProfiles>(environment._shopPanelApiUrl + 'employees-profiles/add-single', profile).toPromise()
    }

    public async getAll(): Promise<EmployeesProfiles[]> {
        return this._http.get<EmployeesProfiles[]>(environment._shopPanelApiUrl + 'employees-profiles/get-all').toPromise()
    }

    public async delete(profile: EmployeesProfiles): Promise<void> {
        return this._http.post<void>(environment._shopPanelApiUrl + 'employees-profiles/delete', profile).toPromise()
    }
}
