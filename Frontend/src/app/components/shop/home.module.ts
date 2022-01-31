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
import { ProductsPageModule } from './products-page/products-page.module';
import { ListsService } from 'src/app/services/shop/lists.service';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { UserOrderListModule } from './user-order-list/user-order-list.module';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { CategoryService } from 'src/app/services/shop/category.service';
import { ProductsService } from 'src/app/services/shop/product.service';
import { ProductModule } from './product/product.module';
import { RatingModule } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
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
    FavoritesProductsModule,
    ProductsPageModule,
    UserOrderListModule,
    ProductModule,
    RatingModule,
    FormsModule
  ],
  providers: [
    AuthenticationService,
    ListsService,
    CustomerCartService,
    CustomerFavoritesProductsService,
    CategoryService,
    ProductsService
  ],
  exports: []
})

export class HomeModule { }
