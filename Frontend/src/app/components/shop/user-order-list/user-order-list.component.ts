import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OrderDisplayDto } from 'src/app/dto/order-display.dto';
import { OrdersDto } from 'src/app/dto/orders.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { OrdersService } from 'src/app/services/shop/orders.service';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';
import { OrderProductsDialog } from '../../shop-panel/orders/order-products/order-products.dialog';

@Component({
  selector: 'app-user-order-list',
  templateUrl: './user-order-list.component.html',
  styleUrls: ['./user-order-list.component.scss']
})
export class UserOrderListComponent implements OnInit {
  public ordersList: OrderDisplayDto[] = [];
  public tableButtons: TableButton[] = [TableButton.Details, TableButton.Document];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'Total value', objectField: 'totalValue' },
      { title: 'Payment type', objectField: 'paymentType' },
      { title: 'Status', objectField: 'status' },
      {
        title: 'Date', objectField: 'date', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' },
        contentMode: ContentMode.DynamicPipe
      },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons }
    ];
  public columnsNames: string[] = [];
  public isLoaded = false;

  constructor(
    private readonly dialog: MatDialog,
    private readonly _ordersService: OrdersService
  ) { }

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    this.ordersList = await this._ordersService.getUserOrders();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  async onDocumentClick(orderDto: OrderDisplayDto) {
    const pdfReq = await this._ordersService.getFvForOrder(orderDto.id);
    const blob = new Blob([pdfReq], { type: 'application/pdf' });
    const fileURL = URL.createObjectURL(blob);
    window.open(fileURL, '_blank');
  }

  async onDetailsClick(orderDto: OrderDisplayDto) {
    this.dialog.open(OrderProductsDialog, {
      data: await this._ordersService.getAllProductsForOrder(orderDto.id),
      width: '800px'
    });
  }
}
