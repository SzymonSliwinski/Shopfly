import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';

@Component({
  selector: 'app-change-password-dialog',
  templateUrl: './change-password.dialog.html',
  styleUrls: ['./change-password.dialog.scss']
})
export class ChangePasswordDialog {
  password: string = '';
  repeatPassword: string = '';
  arePasswordMatch = true;

  constructor(
    private readonly _employeeService: EmployeeService,
    private readonly _dialogRef: MatDialogRef<ChangePasswordDialog>,
  ) { }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public onSaveClick(): void {
    if (this.password !== this.repeatPassword) {
      this.arePasswordMatch = false;
      return;
    }
    this.arePasswordMatch = true;

    this._employeeService.changePassword(this.password);
    this.password = this.repeatPassword = '';
  }
}
