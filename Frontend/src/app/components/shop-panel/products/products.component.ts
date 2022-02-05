import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
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
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public productsList!: ProductDisplayDto[];
  public isChoosenElementVisible!: boolean;
  public categoriesList: Category[] = [];
  private uploadedFile!: File;
  @ViewChild(CategoriesComponent) child!: CategoriesComponent;
  isLoaded = false;
  public isAddMode = false;
  public isEdit = false;

  constructor(
    private readonly _productsService: ProductsService,
    private readonly _categoriesService: CategoriesService,
    public _dialog: MatDialog,
    private _sanitizer: DomSanitizer,
    private _snackBar: MatSnackBar
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Delete];
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
    this.categoriesList = await this._categoriesService.getOnlyChilds();
    this.productsList.forEach(async product => {
      const p = await this.getPhotoForProduct(product.id);
      if (p)
        product.photo = p;
    });
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  public onTabChange(tab: 'products' | 'categories' | 'carriers' | 'lists') {
    this.tab = tab;
  }

  public switchAddMode() {
    if (this.isAddMode) {
      this.isEdit = false;
      this.newProduct = {} as Product;
    }
    this.isAddMode = !this.isAddMode;
  }

  async onAddClick() {
    if (!this.isEdit) {
      await this._productsService.add(this.newProduct);
      await this._productsService.addPhoto(this.uploadedFile);
    }
    else {
      await this._productsService.edit(this.newProduct);
      const v = this.productsList.find(c => c.id == this.newProduct.id);
      this.isLoaded = false;
      v!.name = this.newProduct.name;
      v!.nettoPrice = this.newProduct.nettoPrice;
      v!.bruttoPrice = this.newProduct.bruttoPrice;
      v!.isVisible = this.newProduct.isVisible;
      v!.stock = this.newProduct.stock!;
      v!.category = this.categoriesList.find(c => c.id == this.newProduct.categoryId)!.name;
      this.isLoaded = true;
      //    await this._productsService.editPhoto(this.uploadedFile);
    }
    this._snackBar.open("Saved!", "OK", { duration: 5000 });
  }

  private async getPhotoForProduct(productId: number): Promise<SafeUrl | void> {
    const blob = await this._productsService.getPhoto(productId);
    if (!blob)
      return;
    const urll = URL.createObjectURL(blob!);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
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

  onPhotoUpload(event: any) {
    if (event.target.files && event.target.files.length == 1) {
      this.uploadedFile = event.target.files[0];
      console.log(this.uploadedFile)
    }
  }

  async onDeleteClick(product: ProductDisplayDto) {
    this.isLoaded = false;
    await this._productsService.remove(product.id);
    this.productsList = this.productsList.filter(item => item.id !== product.id);
    this.isLoaded = true;
  }

  async onEditClick(product: ProductDisplayDto) {
    this.newProduct = await this._productsService.getById(product.id);
    this.isAddMode = true;
    this.isEdit = true;
  }
}
