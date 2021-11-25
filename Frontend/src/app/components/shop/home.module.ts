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
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTreeModule } from '@angular/material/tree';
import { IvyCarouselModule } from 'angular-responsive-carousel';
import { MatCardModule } from '@angular/material/card';
import { CarouselModule } from 'primeng/carousel';
import { CartModule } from './cart/cart.module';
import { FavoritesProductsModule } from './favorites-products/favorites-products.module';
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
    BrowserModule,
    MatButtonModule,
    MatIconModule,
    MatTreeModule,
    IvyCarouselModule,
    MatCardModule,
    CarouselModule,
    CartModule,
    FavoritesProductsModule
  ],
  providers: [
    AuthenticationService
  ],
  exports: []
})

export class HomeModule { }
