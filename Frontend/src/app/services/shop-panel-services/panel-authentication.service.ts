import { HttpClient, HttpHeaders, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthenticationDto } from '../../dto/authentication.dto';

@Injectable()
export class PanelAuthenticationService {
  constructor(private _http: HttpClient,
    private readonly router: Router) { }

  public async authenticate(authDto: AuthenticationDto): Promise<boolean | never> {
    var isSucceeded = false;
    await this._http.post<any>(environment._shopPanelApiUrl + 'employees-authentication', authDto).toPromise()
      .then(res => {
        localStorage.setItem(environment._panelStorageKey, JSON.stringify(res));
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
    const storage = JSON.parse(localStorage.getItem(environment._panelStorageKey)!) as { token: { expirationDate: string; userId: number; value: string } };
    await this._http.delete<void>(environment._shopPanelApiUrl +
      'employees-authentication/logout/' +
      storage.token.value, { headers: new HttpHeaders().set('Authorization', storage.token.value) }
    )
      .toPromise()
      .catch(() => {
        localStorage.removeItem(environment._panelStorageKey);
        this.router.navigate(['panel/sign-in']);
      })
      .then(() => {
        localStorage.removeItem(environment._panelStorageKey);
      });
  }
}
