import { Component, Input, OnInit } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { Order } from 'src/app/models/shop-models/order.model';
import { PaymentType } from 'src/app/models/shop-models/payment-type.model';
import { CarriersService } from 'src/app/services/shop/carriers.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  public carriers!: Carrier[];
  public paymentTypes!: PaymentType[];
  public isVatSelected = false;
  public ruleAccepted = false;
  @Input() order!: Order;

  constructor(
    private readonly _carriersService: CarriersService
  ) { }

  async ngOnInit(): Promise<void> {
    this.carriers = await this._carriersService.getAll();

    this.paymentTypes = [
      { id: 1, name: 'Cash', icon: 'payments', isActive: true } as PaymentType,
      { id: 2, name: 'Credit card', icon: 'credit_card', isActive: true } as PaymentType
    ];
  }
}

