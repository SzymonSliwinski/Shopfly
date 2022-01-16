import { Component, OnInit, ViewChild } from '@angular/core';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';
import { Order } from 'src/app/models/shop-models/order.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { CartProductsListComponent } from './cart-products-list/cart-products-list.component';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
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
  public newOrder: Order = {} as Order;
  customerCart: CustomerCart[] = [];
  step1Completed = false;
  step2Completed = false;
  step3Completed = false;

  constructor(private readonly _customerCartService: CustomerCartService) {

  }

  async ngOnInit(): Promise<void> {
    this.customerCart = await this._customerCartService.getAllForLoggedUser();
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
