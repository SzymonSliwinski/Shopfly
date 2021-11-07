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

@NgModule({
    declarations: [
        EmployeesComponent,
        EmployeesListComponent,
        ProfilesListComponent,
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
        MatTabsModule
    ],
    providers: [
    ],
    exports: [
        EmployeesComponent,
    ]
})

export class EmployeesModule { }