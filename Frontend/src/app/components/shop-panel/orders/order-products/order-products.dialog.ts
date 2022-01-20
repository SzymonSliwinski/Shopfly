import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { OrdersProductsService } from 'src/app/services/shop-panel-services/orders-products.service';

@Component({
  selector: 'app-order-products',
  templateUrl: './order-products.dialog.html',
  styleUrls: ['./order-products.dialog.scss']
})
export class OrderProductsDialog implements OnInit {
  productsList: ProductDisplayDto[] = [];
  isLoaded = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<OrderProductsDialog>,
    private readonly _ordersProductsService: OrdersProductsService,
    @Inject(MAT_DIALOG_DATA) public orderId: number,
  ) { }

  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Photo', objectField: 'photo', contentMode: ContentMode.Photo },
      { title: 'Name', objectField: 'name' },
      { title: 'Category', objectField: 'category' },
      { title: 'Netto', objectField: 'nettoPrice' },
      { title: 'Brutto', objectField: 'bruttoPrice' },
      { title: 'Visible', objectField: 'isVisible', contentMode: ContentMode.TrueOrFalse },
      { title: 'Stock', objectField: 'stock' },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.refresh();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
  }

  async refresh(): Promise<void> {
    this.isLoaded = false;
    this.productsList = await this._ordersProductsService.getAllProductsForOrder(this.orderId);
    this.isLoaded = true;
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

}
