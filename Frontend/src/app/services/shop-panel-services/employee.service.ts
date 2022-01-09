import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ChangePasswordDto } from 'src/app/dto/change-password.dto';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmployeeService {
    constructor(private _http: HttpClient) { }

    public async add(employee: Employee): Promise<Employee> {
        return this._http.post<Employee>(environment._shopPanelApiUrl + 'employee', employee).toPromise()
    }

    public async getAll(): Promise<Employee[]> {
        return this._http.get<Employee[]>(environment._shopPanelApiUrl + 'employee/get-all').toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopPanelApiUrl + 'employee/' + id).toPromise()
    }

    public async edit(employee: Employee): Promise<Employee> {
        return this._http.patch<Employee>(environment._shopPanelApiUrl + 'employee', employee).toPromise()
    }

    public async changePassword(newPassword: string): Promise<void> {
        const storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };
        const payload = {
            userId: storage.token.userId,
            newPassword: newPassword
        } as ChangePasswordDto;
        this._http.patch<void>(environment._shopPanelApiUrl + `employee/change-password`, payload).toPromise()
    }
}
