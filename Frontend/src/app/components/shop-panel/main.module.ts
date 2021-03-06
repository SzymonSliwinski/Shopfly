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
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';
import { OrdersModule } from './orders/orders.module';
import { ProductsModule } from './products/products.module';
import { CustomersModule } from './customers/customers.module';
import { ShopSettingsModule } from './shop-settings/shop-settings.module';
import { ApiModule } from './api/api.module';
import { ImportModule } from './import/import.module';
import { EmployeesModule } from './employees/employees.module';
import { ChartsModule } from './charts/charts.module';
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
    OrdersModule,
    ProductsModule,
    CustomersModule,
    ShopSettingsModule,
    ImportModule,
    ApiModule,
    EmployeesModule,
    ChartsModule,
  ],
  providers: [
    PanelAuthenticationService,
  ],
  exports: [
    MainComponent,
    SignInComponent,
  ]
})

export class MainModule { }
