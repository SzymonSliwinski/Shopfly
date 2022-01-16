import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthenticationDto } from '../../dto/authentication.dto';

@Injectable()
export class ShopAuthenticationService {
    constructor(
        private _http: HttpClient,
        private readonly _router: Router) { }

    public async authenticate(authDto: AuthenticationDto): Promise<boolean | never> {
        var isSucceeded = false;
        await this._http.post<any>(environment._shopApiUrl + 'customers-authentication', authDto).toPromise()
            .then(res => {
                sessionStorage.setItem(environment._shopStorageKey, JSON.stringify(res));
                isSucceeded = true;
            })
            .catch(e => {
                if (e.status === 401)
                    return false;

                throw new Error(e.message || e);
            });

        return isSucceeded;
    }

    public async logout(): Promise<void> {
        const storage = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };

        await this._http.delete<void>(environment._shopApiUrl +
            'customers-authentication/logout/' +
            storage.token.value, { headers: new HttpHeaders().set('Authorization', storage.token.value) }
        ).toPromise()
            .finally(() => {
                sessionStorage.removeItem(environment._shopStorageKey);
                this._router.navigate(['']);
            });
    }
}

