import { Component, OnInit } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';

@Component({
  selector: 'app-cart-products-list',
  templateUrl: './cart-products-list.component.html',
  styleUrls: ['./cart-products-list.component.scss']
})
export class CartProductsListComponent implements OnInit {
  public customerCart!: CustomerCart[];
  constructor(
    private readonly _customerCartService: CustomerCartService
  ) { }

  async ngOnInit(): Promise<void> {
    this.customerCart = await this._customerCartService.getAllForLoggedUser();
  }

  public getTotalBruttoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.bruttoPrice;
    });

    return result;
  }
  getTotalNettoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.nettoPrice;
    });

    return result;
  }
}
