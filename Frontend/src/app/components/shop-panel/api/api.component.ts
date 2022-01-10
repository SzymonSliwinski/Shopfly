import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { ApiService } from 'src/app/services/shop-panel-services/api.service';
import { TableButton } from '../../shared/data-table/data-table.component';

@Component({
  selector: 'app-api',
  templateUrl: './api.component.html',
  styleUrls: ['./api.component.scss']
})
export class ApiComponent implements OnInit {
  isApiOn: boolean = false;
  apiKeys!: ApiAccessKey[];
  isLoaded = false;

  constructor(
    private readonly _apiService: ApiService,
    private readonly _router: Router
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Delete];
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

  async ngOnInit(): Promise<void> {
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
      this.refresh();
    });
  }

  private async refresh() {
    this.isLoaded = false;
    this.apiKeys = await this._apiService.getAll();
    this.isLoaded = true;

  }

  async onDeleteClick(apiAccessKey: ApiAccessKey) {
    await this._apiService.remove(apiAccessKey.id);
    this.apiKeys = this.apiKeys.filter(c => c.id !== apiAccessKey.id);
  }

  async onEditClick(apiAccessKey: ApiAccessKey) {
    return this._router.navigate([`panel/api/edit/${apiAccessKey.key}`]);
  }
}
