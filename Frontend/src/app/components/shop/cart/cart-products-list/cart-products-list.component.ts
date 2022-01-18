import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';

@Component({
  selector: 'app-cart-products-list',
  templateUrl: './cart-products-list.component.html',
  styleUrls: ['./cart-products-list.component.scss']
})
export class CartProductsListComponent implements OnInit {
  @Input() order!: Order;
  @Input() customerCart!: CustomerCart[];
  isLoaded = false;
  constructor(
    private readonly _customerCartService: CustomerCartService,
    private readonly _router: Router
  ) { }

  async ngOnInit(): Promise<void> {
    this.isLoaded = true;
  }

  public getTotalBruttoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.bruttoPrice;
    });
    this.order.priceTotal = result;
    return result;
  }

  getTotalNettoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.nettoPrice;
    });

    return result;
  }

  async onClearClick() {
    await this._customerCartService.clear();
    this._router.navigate(['']);
  }
}
