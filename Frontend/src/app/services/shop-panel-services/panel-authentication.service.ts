import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AuthenticationDto } from '../../dto/authentication.dto';

@Injectable()
export class PanelAuthenticationService {
  constructor(private _http: HttpClient) { }

  public async authenticate(authDto: AuthenticationDto) {
    return this._http.post<any>(environment._shopPanelApiurl + 'employeesauthentication', authDto).toPromise();
  }
}
