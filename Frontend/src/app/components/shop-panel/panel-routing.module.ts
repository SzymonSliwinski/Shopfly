import { NgModule } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { CustomersComponent } from './customers/customers.component';
import { ShopSettingsComponent } from './shop-settings/shop-settings.component';
import { ApiComponent } from './api/api.component';
import { AddKeyComponent } from './api/add-key/add-key.component';
import { ImportComponent } from './import/import.component';
import { EmployeesComponent } from './employees/employees.component';
import { ChartsComponent } from './charts/charts.component';

const routes: Routes = [
  {
    path: 'panel', component: MainComponent, canActivate: [AuthenticationService],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'orders', component: OrdersComponent, canActivate: [AuthenticationService] },
      { path: 'products', component: ProductsComponent, canActivate: [AuthenticationService] },
      { path: 'customers', component: CustomersComponent, canActivate: [AuthenticationService] },
      { path: 'shop-settings', component: ShopSettingsComponent, canActivate: [AuthenticationService] },
      { path: 'api', component: ApiComponent, canActivate: [AuthenticationService] },
      { path: 'api/add', component: AddKeyComponent, canActivate: [AuthenticationService] },
      { path: 'api/edit/:key', component: AddKeyComponent, canActivate: [AuthenticationService] },
      { path: 'import', component: ImportComponent, canActivate: [AuthenticationService] },
      { path: 'employees', component: EmployeesComponent, canActivate: [AuthenticationService] },
      { path: 'charts', component: ChartsComponent, canActivate: [AuthenticationService] }
    ]
  },
  { path: 'panel/sign-in', component: SignInComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    AuthenticationService
  ],
  exports: [
    RouterModule,
  ]
})

export class PanelRoutingModule { }
