import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { OrdersProductsService } from 'src/app/services/shop-panel-services/orders-products.service';
import { ProductsService } from 'src/app/services/shop/product.service';
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
    private readonly _productsService: ProductsService,
    @Inject(MAT_DIALOG_DATA) private readonly _orderProducts: ProductDisplayDto[],
    private _sanitizer: DomSanitizer,
  ) { }

  public displayedColumns: TableColumnDto[] =
    [
      { title: 'Photo', objectField: 'photo', contentMode: ContentMode.Photo },
      { title: 'Name', objectField: 'name' },
      { title: 'Category', objectField: 'category' },
      { title: 'Netto', objectField: 'nettoPrice' },
      { title: 'Brutto', objectField: 'bruttoPrice' },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.productsList = this._orderProducts;
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });

    this._orderProducts.forEach(async val => {
      val.photo = await this.getPhotoForProduct(val.id!);
    });
    this.isLoaded = true;
  }
  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productsService.getPhoto(productId);
    const urll = URL.createObjectURL(blob!);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }


  public onCloseClick(): void {
    this._dialogRef.close();
  }

}
