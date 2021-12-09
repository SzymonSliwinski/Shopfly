import { Component, OnInit } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { DatePipe } from '@angular/common';
import { TableButton } from '../../shared/data-table/data-table.component';
import { Order } from 'src/app/models/shop-models/order.model';
import { OrderService } from 'src/app/services/shared/orders.service';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  public ordersList!: OrderDisplayDto[];
  public tableButtons: TableButton[] = [TableButton.Delete, TableButton.Details, TableButton.Edit];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Customer name', objectField: 'customerName' },
      { title: 'Total value', objectField: 'totalValue' },
      { title: 'Payment type', objectField: 'paymentType' },
      { title: 'Status', objectField: 'status' },
      { title: 'Date', objectField: 'date', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }, contentMode: ContentMode.DynamicPipe },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons }
    ];
  public columnsNames: string[] = [];
  public isLoaded = false;
  constructor(
    private readonly _orderService: OrderService,
    private readonly dialog: MatDialog
  ) { }

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
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  deleteOrder(order: OrderDisplayDto) {
    this._orderService.delete(order.id);
  }

  editStatus(order: OrderDisplayDto) {
    this.dialog.open(ChangeStatusDialogComponent);
  }

}