import { Component, OnInit } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { TableColumnDto } from 'src/app/dto/table-column.dto';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  public ordersList!: OrderDisplayDto[];
  //public displayedColumns = ['id', 'customerName', 'totalValue', 'paymentType', 'status', 'date', 'buttons'];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id', hasAdditionalContent: false, additionalContent: null },
      { title: 'Customer Name', objectField: 'customerName', hasAdditionalContent: false, additionalContent: null },
      { title: 'Total value', objectField: 'totalValue', hasAdditionalContent: false, additionalContent: null },
      { title: 'Payment type', objectField: 'paymentType', hasAdditionalContent: false, additionalContent: null },
      { title: 'Status', objectField: 'status', hasAdditionalContent: false, additionalContent: null },
      { title: 'Date', objectField: 'date', hasAdditionalContent: false, additionalContent: null },
    ];
  public columnsNames: string[] = [];
  public isLoaded = false;
  constructor() { }

  ngOnInit(): void {
    this.isLoaded = false;
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
    }];

    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField);
    });
    this.isLoaded = true;
  }
}