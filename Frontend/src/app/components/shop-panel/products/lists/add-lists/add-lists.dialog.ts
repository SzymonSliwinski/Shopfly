import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { HomeProductsList } from 'src/app/models/shop-models/home-products-lists.model';
import { Product } from 'src/app/models/shop-models/product.model';
import { ListsService } from 'src/app/services/shop-panel-services/lists.service';
import { ProductsService } from 'src/app/services/shop-panel-services/products.service';

@Component({
  selector: 'app-add-lists',
  templateUrl: './add-lists.dialog.html',
  styleUrls: ['./add-lists.dialog.scss']
})
export class AddListsDialog implements OnInit {
  public homeList: HomeList = {} as HomeList;
  public allProducts: Product[] = [];
  public selectedProducts: Product[] = [];
  private isEditMode = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<HomeList>,
    private readonly _listsService: ListsService,
    private readonly _productsService: ProductsService,
    @Inject(MAT_DIALOG_DATA) public editList?: HomeList,
  ) { }

  async ngOnInit(): Promise<void> {
    this.homeList.isVisible = true;
    if (this.editList) {
      this.homeList = JSON.parse(JSON.stringify(this.editList));
      this.isEditMode = true;
    }
    this.allProducts = await this._productsService.getAll();
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (!this.isEditMode) {
      this.homeList.homeProductsLists = [];
      this.selectedProducts.forEach(c => {
        this.homeList.homeProductsLists.push(
          {
            productId: c.id,
          } as HomeProductsList
        )
      });
      await this._listsService.add(this.homeList);
      this.editList = {} as HomeList;
      this._dialogRef.close(this.editList);
    }
    else {
      await this._listsService.edit(this.homeList);
      this.editList = this.homeList;
      this._dialogRef.close();
    }
  }

  onProductSelect(product: Product) {
    let foundProduct = this.selectedProducts.find(c => c.id === product.id);
    if (!foundProduct)
      this.selectedProducts.push(product);
    else
      this.selectedProducts = this.selectedProducts.filter(c => c.id !== product.id);
  }
}
