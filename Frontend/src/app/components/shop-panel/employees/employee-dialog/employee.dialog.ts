import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';

@Component({
  selector: 'dd-employee-dialog',
  templateUrl: './employee.dialog.html',
  styleUrls: ['./employee.dialog.scss']
})
export class EmployeeDialog implements OnInit {
  public employee: Employee = {} as Employee;
  public repeatedPassword: string = '';
  private isEditMode = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<EmployeeDialog>,
    private readonly _employeeService: EmployeeService,
    @Inject(MAT_DIALOG_DATA) public editEmployee?: Employee,
  ) { }

  ngOnInit(): void {
    this.employee.isActive = true;
    if (this.editEmployee) {
      this.employee = this.editEmployee;
      this.isEditMode = true;
    }
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (!this.isEditMode) {
      await this._employeeService.add(this.employee);
      this.employee = {} as Employee;
      this.repeatedPassword = '';
      this.employee.isActive = true;
    }
    else {
      await this._employeeService.edit(this.employee);
      this.employee.password = '';
      this._dialogRef.close();
    }
  }

}
