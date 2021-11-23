import { Component, OnInit } from '@angular/core';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { PaymentType } from 'src/app/models/shop-models/payment-type.model';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {
  public carriers!: Carrier[];
  public paymentTypes!: PaymentType[];
  public isVatSelected = false;
  constructor() { }

  ngOnInit(): void {
    this.carriers = [
      {
        id: 1, name: 'DHL', cost: 20.21, deliveryDaysMaximum: 3, deliveryDaysMinimum: 1,
        logo: 'https://www.dpdhl-brands.com/dhl/en/guides/design-basics/logo-and-claim/_jcr_content/opener/image.coreimg.100.2048.png/1595554700344/logo-opener.png',
        isActive: true
      },
      {
        id: 2, name: 'InPost', cost: 19.99, deliveryDaysMaximum: 3, deliveryDaysMinimum: 1,
        logo: 'https://jakimkurierem.pl/logo_kuriera/inpost_logo.png',
        isActive: true
      }
    ];

    this.paymentTypes = [
      { id: 1, name: 'Cash', icon: 'payments', isActive: true },
      { id: 2, name: 'Credit card', icon: 'credit_card', isActive: true }
    ];
  }
}

