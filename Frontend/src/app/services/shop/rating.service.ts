import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Rating } from 'src/app/models/shop-models/rating.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class RatingService {
    constructor(private _http: HttpClient) { }

    public async add(payload: Rating): Promise<Rating> {
        return this._http.post<Rating>(environment._shopApiUrl + 'shop/rating', payload).toPromise()
    }
}
