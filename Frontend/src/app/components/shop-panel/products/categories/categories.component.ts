import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Category } from 'src/app/models/shop-models/category.model';
import { CategoriesService } from 'src/app/services/shop-panel-services/categories.service';
import { AddCategoryDialog } from './add-category/add-category.dialog';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {
  public categoriesList!: Category[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    public _dialog: MatDialog,
    private readonly _categoriesService: CategoriesService
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Delete];
  public menuButtons: MenuButton[] = [];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Position', objectField: 'position' },
      { title: 'Root', objectField: 'isRoot', contentMode: ContentMode.TrueOrFalse },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  async ngOnInit(): Promise<void> {
    this.refresh();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
  }

  async refresh() {
    this.isLoaded = false;
    this.categoriesList = await this._categoriesService.getAll();
    this.isLoaded = true;
  }

  public async onDeleteClick(category: Category) {
    await this._categoriesService.delete(category.id);
    this.categoriesList = this.categoriesList.filter(c => c.id !== category.id);
  }

  public async onEditClick(category: Category) {
    const dialog = this._dialog.open(AddCategoryDialog, {
      data: category
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    });
  }

}
