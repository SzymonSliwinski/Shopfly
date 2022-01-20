import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { environment } from 'src/environments/environment';

@Injectable()
export class OrdersProductsService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async getAllProductsForOrder(orderId: number): Promise<ProductDisplayDto[]> {
        return this._http.get<ProductDisplayDto[]>(environment._shopPanelApiUrl + `ordersproducts/get-all-for-order/${orderId}`,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }
}
