import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';

@Component({
  selector: 'app-add-employee-dialog',
  templateUrl: './add-employee.dialog.html',
  styleUrls: ['./add-employee.dialog.scss']
})
export class AddEmployeeDialog implements OnInit {
  public newEmployee: Employee = {} as Employee;
  public repeatedPassword: string = '';

  constructor(
    private readonly _dialogRef: MatDialogRef<AddEmployeeDialog>,
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
  }

}
