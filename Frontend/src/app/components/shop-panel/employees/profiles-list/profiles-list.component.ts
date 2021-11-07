import { Component, OnInit } from '@angular/core';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';

@Component({
  selector: 'app-profiles-list',
  templateUrl: './profiles-list.component.html',
  styleUrls: ['./profiles-list.component.scss']
})
export class ProfilesListComponent implements OnInit {
  public profilesList!: Profile[];

  public isChoosenElementVisible!: boolean;
  isLoaded = false;
  constructor() { }
  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu];
  public menuButtons: MenuButton[] = [MenuButton.Delete, MenuButton.Details];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.isLoaded = false;
    this.profilesList = [{
      id: 1,
      name: 'Admini',
    },
    {
      id: 2,
      name: 'Obsługa zamówień',

    }];
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }
}
