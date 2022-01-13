import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Category } from 'src/app/models/shop-models/category.model';
import { CategoriesService } from 'src/app/services/shop-panel-services/categories.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.dialog.html',
  styleUrls: ['./add-category.dialog.scss']
})
export class AddCategoryDialog implements OnInit {
  public category: Category = {} as Category;
  private isEditMode = false;

  constructor(
    private readonly _dialogRef: MatDialogRef<Category>,
    private readonly _categoryService: CategoriesService,
    @Inject(MAT_DIALOG_DATA) public editCategory?: Category,
  ) { }

  ngOnInit(): void {
    this.category.isActive = true;
    if (this.editCategory) {
      this.category = JSON.parse(JSON.stringify(this.editCategory));
      this.isEditMode = true;
    }
  }

  public onCloseClick(): void {
    this._dialogRef.close();
  }

  public async onSaveClick() {
    if (!this.isEditMode) {
      await this._categoryService.add(this.category);
      this.category = {} as Category;
      this._dialogRef.close(this.category);
    }
    else {
      await this._categoryService.edit(this.category);
      this.editCategory = this.category;
      this._dialogRef.close();
    }
  }
}
