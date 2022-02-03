import { Component, OnInit, ViewChild } from '@angular/core';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Order } from 'src/app/models/shop-models/order.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { CartProductsListComponent } from './cart-products-list/cart-products-list.component';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
// import { ProductsService } from 'src/app/services/shop-panel-services/products.service';
import { ProductsService } from 'src/app/services/shop/product.service';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: { showError: true },
    },
  ],
})
export class CartComponent implements OnInit {
  @ViewChild(CartProductsListComponent) step1!: CartProductsListComponent;
  productsUrl: SafeUrl[] = [];
  public newOrder: Order = {} as Order;
  customerCart: CustomerCart[] = [];
  step1Completed = false;
  step2Completed = false;
  step3Completed = false;
  isLoaded = false;
  constructor(
    private readonly _customerCartService: CustomerCartService,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer,
  ) { }

  async ngOnInit(): Promise<void> {
    this.customerCart = await this._customerCartService.getAllForLoggedUser();
    this.customerCart.forEach(async val => {
      this.productsUrl[val.productId] = await this.getPhotoForProduct(val.productId!);
    });
    this.isLoaded = true;
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob!);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  onStepChange(val: any) {
    if (val.selectedIndex === 1)
      this.step1Completed = true;
    if (val.selectedIndex === 2) {
      this.step2Completed = true;

    }
    if (val.selectedIndex === 3)
      this.step3Completed = true;
  }
}
