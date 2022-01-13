import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ProductDisplayDto } from 'src/app/dto/product-display.dto';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Category } from 'src/app/models/shop-models/category.model';
import { Product } from 'src/app/models/shop-models/product.model';
import { CategoriesService } from 'src/app/services/shop-panel-services/categories.service';
import { ProductsService } from 'src/app/services/shop-panel-services/products.service';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';
import { AddCarrierDialog } from './carriers/add-carrier/add-carrier.dialog';
import { AddCategoryDialog } from './categories/add-category/add-category.dialog';
import { CategoriesComponent } from './categories/categories.component';
import { AddListsDialog } from './lists/add-lists/add-lists.dialog';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public productsList!: ProductDisplayDto[];
  public isChoosenElementVisible!: boolean;
  public categoriesList: Category[] = [];
  @ViewChild(CategoriesComponent) child!: CategoriesComponent;
  isLoaded = false;
  public isAddMode = false;

  constructor(
    private readonly _productsService: ProductsService,
    private readonly _categoriesService: CategoriesService,
    public _dialog: MatDialog
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
  tab: 'products' | 'categories' | 'carriers' | 'lists' = 'products';

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    this.productsList = await this._productsService.getForTable();
    this.categoriesList = await this._categoriesService.getAll();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  public onTabChange(tab: 'products' | 'categories' | 'carriers' | 'lists') {
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

  onAddCarriersClick() {
    const dialog = this._dialog.open(AddCarrierDialog);

    dialog.afterClosed().subscribe(res => {
      this.child.refresh();
    });
  }

  onAddListClick() {
    const dialog = this._dialog.open(AddListsDialog);

    dialog.afterClosed().subscribe(res => {
      this.child.refresh();
    });
  }
}
