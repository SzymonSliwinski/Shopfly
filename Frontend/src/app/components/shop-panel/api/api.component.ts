import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.scss']
})
export class ApiComponent implements OnInit {
  isApiOn: boolean = false;
  apiKeys!: ApiAccessKey[];
  isLoaded = false;
  constructor() { }
  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu];
  public menuButtons: MenuButton[] = [MenuButton.Delete, MenuButton.Details];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Key', objectField: 'key' },
      { title: 'Active', objectField: 'isActive', contentMode: ContentMode.TrueOrFalse },
      {
        title: 'Create date', objectField: 'createDate', contentMode:
          ContentMode.DynamicPipe, pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }
      },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons }
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.isLoaded = false;
    this.apiKeys = [{
      id: 1,
      key: 'r33r372r3278ry',
      isActive: true,
      createDate: new Date()
    }, {
      id: 2,
      key: 'r56r56r56r',
      isActive: true,
      createDate: new Date()
    }
    ];
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

  public onAddKeyClick(): void {

  }

}
