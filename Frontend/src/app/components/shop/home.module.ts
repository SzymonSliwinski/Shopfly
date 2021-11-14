import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../services/authentication.service';
import { HomeComponent } from './home.component';
import { ShopRoutingModule } from './shop-routing.module';
import { NavbarModule } from './navbar/navbar.module';
import { SignInModule } from './sign-in/sign-in.module';
import { SignUpModule } from './sign-up/sign-up.module';
import { SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    HomeComponent,
  ],
  imports: [
    CommonModule,
    ShopRoutingModule,
    NavbarModule,
    SignUpModule,
    SignInModule,
    SidebarModule,
    BrowserModule
  ],
  providers: [
    AuthenticationService
  ],
  exports: []
})

export class HomeModule { }
