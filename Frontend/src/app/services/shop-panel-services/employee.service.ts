import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmployeeService {
    constructor(private _http: HttpClient) { }

    public async add(product: Employee): Promise<Employee> {
        return this._http.post<Employee>(environment._shopPanelApiUrl + 'employee', product).toPromise()
    }

    public async getAll(): Promise<Employee[]> {
        return this._http.get<Employee[]>(environment._shopPanelApiUrl + 'employee/get-all').toPromise()
    }
}
