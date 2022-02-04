import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class ChartService {
    storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

    constructor(private _http: HttpClient) { }

    public async getOrderChart(dateRangeDto: DateRangeDto): Promise<Map<Date, number>[]> {
        return this._http.post<any>(environment._shopPanelApiUrl + 'chart/order-chart-data', dateRangeDto,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getCarrierChart(dateRangeDto: DateRangeDto): Promise<any> {
        return this._http.post(environment._shopPanelApiUrl + 'chart/carrier-chart-data', dateRangeDto,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getPaymentTypeChart(dateRangeDto: DateRangeDto): Promise<any> {
        return this._http.post(environment._shopPanelApiUrl + 'chart/payment-type-chart-data', dateRangeDto,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getNewUsersChart(dateRangeDto: DateRangeDto): Promise<any> {
        return this._http.post(environment._shopPanelApiUrl + 'chart/new-user-chart-data', dateRangeDto,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

    public async getCompleteOrdersChart(dateRangeDto: DateRangeDto): Promise<any> {
        return this._http.post(environment._shopPanelApiUrl + 'chart/complete-order-chart-data', dateRangeDto,
            { headers: new HttpHeaders().set('Authorization', this.storage.token.value) }).toPromise()
    }

}

export interface DateRangeDto {
    from: Date;
    to: Date;
}
