import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';

@Component({
  selector: 'app-panel-navbar',
  templateUrl: './panel-navbar.component.html',
  styleUrls: ['./panel-navbar.component.scss']
})
export class PanelNavbarComponent {

  constructor(
    private readonly _authService: PanelAuthenticationService,
    private readonly _router: Router,
  ) { }

  public async onLogoutClick(): Promise<boolean> {
    await this._authService.logout();
    return this._router.navigate(['panel/sign-in']);
  }
}
