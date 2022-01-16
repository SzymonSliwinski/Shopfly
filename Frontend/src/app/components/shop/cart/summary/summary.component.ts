import { Component, Input, OnInit } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent implements OnInit {
  public products!: CustomerCart[];
  @Input() order!: Order;
  @Input() customerCart!: CustomerCart[];
  constructor() { }

  ngOnInit(): void {
    console.log(this.order)
    console.log(this.order.paymentType)
    this.products = this.customerCart;
  }


}
