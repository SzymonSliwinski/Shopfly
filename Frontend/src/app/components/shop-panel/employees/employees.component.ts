import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeDialog } from './employee-dialog/employee.dialog';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ProfileDialog } from './profile-dialog/profile.dialog';
import { ProfilesListComponent } from './profiles-list/profiles-list.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  @ViewChild(ProfilesListComponent) profileListComponent!: ProfilesListComponent;
  @ViewChild(EmployeesListComponent) employeeListComponent!: EmployeesListComponent;

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
    const dialog = this._dialog.open(EmployeeDialog);

    dialog.afterClosed().subscribe(res => {
      this.employeeListComponent.refresh();
    });
  }

  public onAddProfileClick(): void {
    const dialog = this._dialog.open(ProfileDialog);

    dialog.afterClosed().subscribe(res => {
      this.profileListComponent.refresh();
    });
  }
}
