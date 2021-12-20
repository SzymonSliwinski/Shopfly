import { Component, OnInit } from '@angular/core';
import { EmployeeDialog } from './employee-dialog/employee.dialog';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  tab: 'employees' | 'profiles' = 'employees';
  constructor(
    public _dialog: MatDialog,
  ) { }

  ngOnInit(): void {
  }

  public onTabChange(tab: 'employees' | 'profiles') {
    this.tab = tab;
  }

  public onAddEmployeeClick(): void {
    const dialogRef = this._dialog.open(EmployeeDialog);

  }


}
