import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from 'src/app/models/shop-models/customer.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CustomerService {
    constructor(private _http: HttpClient) { }

    public async add(customer: Customer): Promise<Customer> {
        return this._http.post<Customer>(environment._shopApiUrl + 'shop/customer', customer).toPromise()
    }

    public async getById(id: number): Promise<Customer> {
        return this._http.get<Customer>(environment._shopApiUrl + `shop/customer/by-id/${id}`).toPromise()
    }

    public async delete(id: number): Promise<void> {
        return this._http.delete<void>(environment._shopApiUrl + 'shop/customer/' + id).toPromise()
    }

    public async edit(customer: Customer): Promise<Customer> {
        return this._http.patch<Customer>(environment._shopApiUrl + 'shop/customer', customer).toPromise()
    }
}
