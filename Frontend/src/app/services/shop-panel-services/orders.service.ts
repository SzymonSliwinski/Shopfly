import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrdersDto } from 'src/app/dto/orders.dto';
import { Order } from 'src/app/models/shop-models/order.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class OrdersService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async getViewAsDto(): Promise<OrdersDto> {
        return this._http.get<OrdersDto>(environment._shopPanelApiUrl + 'order/get-view-data',
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }
}
