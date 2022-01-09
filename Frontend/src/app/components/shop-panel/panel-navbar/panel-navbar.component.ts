import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';
import { ChangePasswordDialog } from './change-password-dialog/change-password.dialog';

@Component({
  selector: 'app-panel-navbar',
  templateUrl: './panel-navbar.component.html',
  styleUrls: ['./panel-navbar.component.scss']
})
export class PanelNavbarComponent {
  constructor(
    private readonly _authService: PanelAuthenticationService,
    private readonly _router: Router,
    public _dialog: MatDialog,

  ) { }

  public async onLogoutClick(): Promise<boolean> {
    await this._authService.logout();
    return this._router.navigate(['panel/sign-in']);
  }

  public async onChangePasswordClick(): Promise<void> {
    const dialog = this._dialog.open(ChangePasswordDialog);

    dialog.afterClosed().subscribe(res => {

    });
  }
}
