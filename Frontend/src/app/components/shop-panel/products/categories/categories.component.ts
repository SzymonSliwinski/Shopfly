import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Category } from 'src/app/models/shop-models/category.model';
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
    public _dialog: MatDialog
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu, TableButton.Delete];
  public menuButtons: MenuButton[] = [];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Root', objectField: 'isRoot', contentMode: ContentMode.TrueOrFalse },
      { title: 'Active', objectField: 'isActive', contentMode: ContentMode.TrueOrFalse },
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
    //  this.employeesList = await this._employeeService.getAll();
    this.isLoaded = true;
  }

  public async onDeleteClick(employee: Category) {
    //await this._employeeService.delete(employee.id);
    // this.employeesList = this.employeesList.filter(c => c.id !== employee.id);
  }

  public async onEditClick(employee: Category) {
    const dialog = this._dialog.open(AddCategoryDialog, {
      data: employee
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    });
  }



}
