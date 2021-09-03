import { HttpClient, } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthenticationDto } from '../../dto/authentication.dto';

@Injectable()
export class PanelAuthenticationService {
  constructor(private _http: HttpClient) { }

  public async authenticate(authDto: AuthenticationDto): Promise<boolean | never> {
    var isSucceeded = false;
    await this._http.post<any>(environment._shopPanelApiurl + 'employeesauthentication', authDto).toPromise()
      .then(res => {
        localStorage.setItem(environment._panelStorageKey, res);
        isSucceeded = true;
      })
      .catch(e => {
        if (e.status === 401)
          return false;

        throw new Error(e.message || e);
      });

    return isSucceeded;
  }
}
