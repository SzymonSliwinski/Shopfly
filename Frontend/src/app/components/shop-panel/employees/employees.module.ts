import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { SharedModule } from '../../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { EmployeesComponent } from './employees.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { ProfilesListComponent } from './profiles-list/profiles-list.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDialogModule } from '@angular/material/dialog';
import { EmployeeDialog } from './employee-dialog/employee.dialog';
import { ProfileDialog } from './profile-dialog/profile.dialog';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ProfileService } from 'src/app/services/shop-panel-services/profile.service';
import { EmployeeProfilesDialog } from './employee-profiles-dialog/employee-profiles.dialog';
import { EmployeesProfilesService } from 'src/app/services/shop-panel-services/employees-profiles.service';

@NgModule({
    declarations: [
        EmployeesComponent,
        EmployeesListComponent,
        ProfilesListComponent,
        EmployeeDialog,
        ProfileDialog,
        EmployeeProfilesDialog
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatMenuModule,
        MatTableModule,
        MatButtonModule,
        MatPaginatorModule,
        MatChipsModule,
        MatFormFieldModule,
        SharedModule,
        MatSelectModule,
        MatTabsModule,
        MatDialogModule,
        MatInputModule,
        FormsModule,
        MatCheckboxModule
    ],
    providers: [
        EmployeeService,
        ProfileService,
        EmployeesProfilesService
    ],
    exports: [
        EmployeesComponent,
    ]
})

export class EmployeesModule { }