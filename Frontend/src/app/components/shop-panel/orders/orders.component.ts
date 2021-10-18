import { Component, OnInit } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { TableColumnDto } from 'src/app/dto/table-column.dto';
import { DatePipe } from '@angular/common';

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
      { title: 'ID', objectField: 'id', additionalContent: null },
      { title: 'Customer name', objectField: 'customerName', additionalContent: null },
      { title: 'Total value', objectField: 'totalValue', additionalContent: null },
      { title: 'Payment type', objectField: 'paymentType', additionalContent: null },
      { title: 'Status', objectField: 'status', additionalContent: null },
      { title: 'Date', objectField: 'date', additionalContent: null, usePipe: true, pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' } },
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