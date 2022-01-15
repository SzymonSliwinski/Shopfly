import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ShopRoutingModule } from '../shop-routing.module';
import { ShopAuthenticationService } from 'src/app/services/shop/shop-authentication.service';
import { CustomerService } from 'src/app/services/shop/customer-service';
@NgModule({
  declarations: [
    NavbarComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatMenuModule,
    FormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatTooltipModule,
    MatSidenavModule,
    ShopRoutingModule
  ],
  providers: [
    ShopAuthenticationService,
    CustomerService
  ],
  exports: [
    NavbarComponent,
  ]
})

export class NavbarModule { }
