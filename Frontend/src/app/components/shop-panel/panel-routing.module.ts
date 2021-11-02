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

const routes: Routes = [
  {
    path: 'panel', component: MainComponent, canActivate: [AuthenticationService],
    children: [
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthenticationService] },
      { path: 'orders', component: OrdersComponent, canActivate: [AuthenticationService] },
      { path: 'products', component: ProductsComponent, canActivate: [AuthenticationService] },
      { path: 'customers', component: CustomersComponent, canActivate: [AuthenticationService] },
      { path: 'shop-settings', component: ShopSettingsComponent, canActivate: [AuthenticationService] }
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
