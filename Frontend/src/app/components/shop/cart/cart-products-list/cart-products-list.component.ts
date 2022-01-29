import { Component, Input, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { ProductsService } from 'src/app/services/shop/product.service';

@Component({
  selector: 'app-cart-products-list',
  templateUrl: './cart-products-list.component.html',
  styleUrls: ['./cart-products-list.component.scss']
})
export class CartProductsListComponent implements OnInit {
  @Input() order!: Order;
  @Input() customerCart!: CustomerCart[];
  isLoaded = false;
  public productsUrl: SafeUrl[] = [];

  constructor(
    private readonly _customerCartService: CustomerCartService,
    private readonly _customerFavoritesServices: CustomerFavoritesProductsService,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer,
    private readonly _router: Router
  ) { }

  async ngOnInit(): Promise<void> {
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

  public getTotalBruttoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.bruttoPrice * p.quantity!;
    });
    this.order.priceTotal = result;
    return result;
  }

  getTotalNettoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.nettoPrice * p.quantity!;
    });

    return result;
  }

  async onClearClick() {
    await this._customerCartService.clear();
    this._router.navigate(['']);
  }

  onFavoritesClick(id: number) {
    this._customerFavoritesServices.add(id);
  }

  onRemoveClick(id: number) {
    this._customerCartService.removeProduct(id);
    this.customerCart = this.customerCart.filter(c => c.productId !== id);
  }

  public onProductClick(productId: number) {
    this._router.navigate([`product/${productId}`]);
  }
}
