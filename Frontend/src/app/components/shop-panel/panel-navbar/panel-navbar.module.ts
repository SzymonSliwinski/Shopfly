import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelNavbarComponent } from './panel-navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';
import { ChangePasswordDialog } from './change-password-dialog/change-password.dialog';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';
@NgModule({
  declarations: [
    PanelNavbarComponent,
    ChangePasswordDialog,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatMenuModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule
  ],
  providers: [
    PanelAuthenticationService,
    EmployeeService
  ],
  exports: [
    PanelNavbarComponent,
  ]
})

export class PanelNavbarModule { }
