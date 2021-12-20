import { Component, Input, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';

@Component({
  selector: 'dd-employee-dialog',
  templateUrl: './employee.dialog.html',
  styleUrls: ['./employee.dialog.scss']
})
export class EmployeeDialog implements OnInit {
  public newEmployee: Employee = {} as Employee;
  public repeatedPassword: string = '';
  constructor(
    private readonly _dialogRef: MatDialogRef<EmployeeDialog>,
    private readonly _employeeService: EmployeeService
  ) { }

  ngOnInit(): void {
    this.newEmployee.isActive = true;
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public onSaveClick() {
    this._employeeService.add(this.newEmployee);
    this.newEmployee = {} as Employee;
    this.newEmployee.isActive = true;
  }

}
