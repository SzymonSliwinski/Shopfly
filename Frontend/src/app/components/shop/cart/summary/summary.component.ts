import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { OrdersProducts } from 'src/app/models/shop-models/orders-products.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { OrdersService } from 'src/app/services/shop/orders.service';
import { ProductsService } from 'src/app/services/shop/product.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent implements OnInit {
  public products!: CustomerCart[];
  @Input() order!: Order;
  @Input() customerCart!: CustomerCart[];
  public productsUrl: SafeUrl[] = [];
  isLoaded = false;
  constructor(
    private readonly _ordersService: OrdersService,
    private readonly _customerCartService: CustomerCartService,
    private readonly _router: Router,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer,
  ) { }

  ngOnInit(): void {
    this.products = this.customerCart;
    this.order.ordersProducts = [];
    this.order.priceTotal = 0;
    this.products.forEach(val => {
      this.order.priceTotal += val.product!.bruttoPrice;
      this.order.ordersProducts!.push(
        {
          productId: val.productId,
          productQuantity: val.quantity!
        } as OrdersProducts
      );
    });
    this.order.carrierId = this.order.carrier!.id;
    this.order.paymentTypeId = this.order.paymentType!.id;
    this.order.customerId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;

    this.customerCart.forEach(async val => {
      this.productsUrl[val.productId] = await this.getPhotoForProduct(val.productId!);
    });
    this.isLoaded = true;
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  async onSubmit() {
    this.order.carrier = null;
    this.order.paymentType = null; console.log(this.order)
    await this._ordersService.add(this.order);
    await this._customerCartService.clear();
    this._router.navigate(['']);
  }
}
