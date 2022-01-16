import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { OrdersProducts } from 'src/app/models/shop-models/orders-products.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { OrdersService } from 'src/app/services/shop/orders.service';
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
  constructor(
    private readonly _ordersService: OrdersService,
    private readonly _customerCartService: CustomerCartService,
    private readonly _router: Router
  ) { }

  ngOnInit(): void {
    this.products = this.customerCart;
    this.order.ordersProducts = [];
    this.products.forEach(val => {
      this.order.ordersProducts!.push(
        {
          //   order: this.order,
          productId: val.productId,
          productQuantity: val.quantity!
        } as OrdersProducts
      );
    });
    this.order.carrierId = this.order.carrier!.id;
    this.order.paymentTypeId = this.order.paymentType!.id;
    this.order.customerId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
  }

  async onSubmit() {
    this.order.carrier = null;
    this.order.paymentType = null;
    await this._ordersService.add(this.order);
    await this._customerCartService.clear();
    this._router.navigate(['']);
  }
}
