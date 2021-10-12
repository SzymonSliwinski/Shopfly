import { Component, OnInit } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  public ordersList!: OrderDisplayDto[];
  public displayedColumns = ['id', 'customerName', 'totalValue', 'paymentType', 'status', 'date', 'buttons'];
  constructor() { }

  ngOnInit(): void {
    this.ordersList = [{
      id: 1,
      customerName: 'Jan Brunow',
      totalValue: 1234.21,
      paymentType: 'PayPal',
      status: 'new',
      date: new Date()
    },
    {
      id: 2,
      customerName: 'Jan Kalewicz',
      totalValue: 2393.23,
      paymentType: 'VISA',
      status: 'sent',
      date: new Date()
    }
    ]
  }

}
