import { Component, OnInit } from '@angular/core';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Product } from 'src/app/models/shop-models/product.model';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public productsList!: ProductDisplayDto[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;
  constructor() { }
  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu];
  public menuButtons: MenuButton[] = [MenuButton.Delete, MenuButton.Details];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Photo', objectField: 'photo', contentMode: ContentMode.Photo },
      { title: 'Name', objectField: 'name' },
      { title: 'Category', objectField: 'category' },
      { title: 'Netto', objectField: 'nettoPrice' },
      { title: 'Brutto', objectField: 'bruttoPrice' },
      { title: 'Visible', objectField: 'isVisible', contentMode: ContentMode.TrueOrFalse },
      { title: 'Quantity', objectField: 'quantity' },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.isLoaded = false;
    this.productsList = [{
      id: 1,
      name: 'produkt1 produkt1 produkt1 123',
      photo: 'https://i.picsum.photos/id/656/200/200.jpg?hmac=MNTvk8A5MPGsxw6vlhoVkWBGsnwW_UjuWcxVp-gQZI8',
      category: 'kategoria 1',
      nettoPrice: 20.32,
      bruttoPrice: 38.00,
      isVisible: true,
      quantity: 322
    }, {
      id: 2,
      name: 'produkt2',
      photo: 'https://i.picsum.photos/id/656/200/200.jpg?hmac=MNTvk8A5MPGsxw6vlhoVkWBGsnwW_UjuWcxVp-gQZI8',
      category: 'kategoria 1',
      nettoPrice: 22.32,
      bruttoPrice: 33.00,
      isVisible: false,
      quantity: 232
    }
    ];
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

}