import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PanelNavbarModule } from './panel-navbar/panel-navbar.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PanelRoutingModule } from './panel-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';
@NgModule({
  declarations: [
    MainComponent,
    DashboardComponent,
    SignInComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PanelNavbarModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    PanelRoutingModule,
  ],
  providers: [

  ],
  exports: [
    MainComponent,
    SignInComponent,
  ]
})

export class MainModule { }
