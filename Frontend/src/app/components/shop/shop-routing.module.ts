import { NgModule } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CartComponent } from './cart/cart.component';
import { FavoritesProductsComponent } from './favorites-products/favorites-products.component';
import { ProductsPageComponent } from './products-page/products-page.component';
import { UserOrderListComponent } from './user-order-list/user-order-list.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent,
    children: [
      { path: 'sign-in', component: SignInComponent },
      { path: 'sign-up', component: SignUpComponent },
      { path: 'cart', component: CartComponent },
      { path: 'favorites', component: FavoritesProductsComponent },
      { path: 'products/:page', component: ProductsPageComponent },
      { path: 'my-orders', component: UserOrderListComponent },
      { path: 'product/:id', component: ProductComponent }
    ]
  }
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

export class ShopRoutingModule { }
