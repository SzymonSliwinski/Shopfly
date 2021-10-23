import { Component, Input, TemplateRef } from '@angular/core';
import { TableColumnDto, ContentMode } from 'src/app/dto/table-column.dto';

export enum TableButton {
  delete,
  edit,
  details,
  menu
}

@Component({
  selector: 'shared-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent<T> {
  @Input() dataSource!: T[];
  @Input() displayedColumns!: TableColumnDto[];
  @Input() columnsNames!: string[];
  @Input() hasSelectableRows: boolean = false; //TO DO
  @Input() buttons: TableButton[] = [];
  @Input() component: any;
  @Input() data: any;
  contentMode = ContentMode;
  optionTemplateRef!: TemplateRef<any>;
  tableButton = TableButton;


  constructor() { }

  public onDeleteClick(): void {
    console.log('delete' + this.data);
  }

  public onDetailsClick(): void {
    console.log('details' + this.data);
  }

}
