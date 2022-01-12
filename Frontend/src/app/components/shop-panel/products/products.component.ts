import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Product } from 'src/app/models/shop-models/product.model';
import { ProductsService } from 'src/app/services/shop-panel-services/products.service';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';
import { AddCategoryDialog } from './categories/add-category/add-category.dialog';
import { CategoriesComponent } from './categories/categories.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public productsList!: ProductDisplayDto[];
  public isChoosenElementVisible!: boolean;
  @ViewChild(CategoriesComponent) child!: CategoriesComponent;

  isLoaded = false;
  public isAddMode = false;

  constructor(
    private readonly _productsService: ProductsService,
    public _dialog: MatDialog,

  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu];
  public menuButtons: MenuButton[] = [MenuButton.Delete, MenuButton.Details];
  public newProduct = {} as Product;
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
  tab: 'products' | 'categories' = 'products';

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    this.productsList = await this._productsService.getForTable();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  public onTabChange(tab: 'products' | 'categories') {
    this.tab = tab;
  }

  public switchAddMode() {
    this.isAddMode = !this.isAddMode;
  }

  async onAddClick() {
    await this._productsService.add(this.newProduct);
  }

  onAddCategoryClick() {
    const dialog = this._dialog.open(AddCategoryDialog);

    dialog.afterClosed().subscribe(res => {
      this.child.refresh();
    });
  }
}