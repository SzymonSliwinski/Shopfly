import { Component, OnInit } from '@angular/core';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { DatePipe } from '@angular/common';
import { TableButton } from '../../shared/data-table/data-table.component';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';
import { MatDialog, } from '@angular/material/dialog';
import { OrdersDto } from 'src/app/dto/orders.dto';
import { OrdersService } from 'src/app/services/shop-panel-services/orders.service';
import { OrderProductsDialog } from './order-products/order-products.dialog';
import { OrdersProductsService } from 'src/app/services/shop-panel-services/orders-products.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  public ordersList: OrderDisplayDto[] = [];
  viewDto!: OrdersDto;
  public tableButtons: TableButton[] = [TableButton.Details, TableButton.Edit];
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
    private readonly dialog: MatDialog,
    private readonly _ordersService: OrdersService,
    private readonly _ordersProductsService: OrdersProductsService,
  ) { }

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    this.viewDto = await this._ordersService.getViewAsDto();
    this.ordersList = this.viewDto.orderDisplayDto;
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  editStatus(order: OrderDisplayDto) {
    const dialogRef = this.dialog.open(ChangeStatusDialogComponent, {
      data: {
        actualStatus: order.status,
        orderId: order.id
      }
    });

    dialogRef.afterClosed().subscribe(res => {
      order.status = res;
    })
  }

  async onDetailsClick(orderDto: OrderDisplayDto) {
    this.dialog.open(OrderProductsDialog, {
      data: await this._ordersProductsService.getAllProductsForOrder(orderDto.id),
      width: '800px'
    });
  }
}