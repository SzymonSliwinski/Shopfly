import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { ListsService } from 'src/app/services/shop-panel-services/lists.service';
import { AddListsDialog } from './add-lists/add-lists.dialog';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.scss']
})
export class ListsComponent implements OnInit {
  public categoriesList!: HomeList[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    public _dialog: MatDialog,
    private readonly _homeListsService: ListsService
  ) { }

  public tableButtons: TableButton[] = [TableButton.Delete];
  public menuButtons: MenuButton[] = [];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'title' },
      { title: 'Is visible', objectField: 'isVisible', contentMode: ContentMode.TrueOrFalse },
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
    this.categoriesList = await this._homeListsService.getAll();
    this.isLoaded = true;
  }

  public async onDeleteClick(homeLists: HomeList) {
    await this._homeListsService.delete(homeLists.id);
    this.categoriesList = this.categoriesList.filter(c => c.id !== homeLists.id);
  }

  public async onEditClick(homeLists: HomeList) {
    const dialog = this._dialog.open(AddListsDialog, {
      data: homeLists
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    });
  }

}
