import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { TableColumnDto, ContentMode } from 'src/app/dto/table-column.dto';

export enum TableButton {
  Delete,
  Edit,
  Details,
  Menu
}

@Component({
  selector: 'shared-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent<T> implements OnInit {
  @Input() dataSource!: T[];
  @Input() displayedColumns!: TableColumnDto[];
  @Input() columnsNames!: string[];
  @Input() hasSelectableRows: boolean = false; //TO DO
  @Input() buttons: TableButton[] = [];
  @Input() data: any;
  contentMode = ContentMode;
  optionTemplateRef!: TemplateRef<any>;
  tableButton = TableButton;
  isLoaded = false;
  constructor() { }

  ngOnInit() {
    this.isLoaded = false;
    //  if (this.buttons.length > 0)
    //this.displayedColumns.push({ title: 's', isButtonColumn: true, contentMode: ContentMode.Buttons, objectField: 'actions' });
    this.isLoaded = true;
  }

  public onDeleteClick(element: any): void {
    console.log('delete' + element.id);
  }

  public onDetailsClick(element: any): void {
    console.log('details' + element.id);
  }

}
