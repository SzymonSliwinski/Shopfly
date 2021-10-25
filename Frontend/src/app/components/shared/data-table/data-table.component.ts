import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { TableColumnDto, ContentMode } from 'src/app/dto/table-column.dto';

export enum TableButton {
  Delete,
  Edit,
  Details,
  Menu
};

export enum MenuButton {
  Delete,
  Edit,
  Details,
};

@Component({
  selector: 'shared-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent<T>{
  @Input() dataSource!: T[];
  @Input() displayedColumns!: TableColumnDto[];
  @Input() columnsNames!: string[];
  @Input() hasSelectableRows: boolean = false; //TO DO
  @Input() buttons: TableButton[] = [];
  @Input() menuButtons: MenuButton[] = [];
  @Input() data: any;
  contentMode = ContentMode;
  optionTemplateRef!: TemplateRef<any>;
  tableButton = TableButton;
  menuButton = MenuButton;
  public afterMenuClickedElement: any;

  constructor(private readonly _sanitizer: DomSanitizer) { }

  public onDeleteClick(element: any): void {
    console.log(element);
    console.log(element.id);
  }

  public onDetailsClick(element: any): void {
    this.afterMenuClickedElement = element;
    console.log('details' + element.id);
  }

  public onMenuClick(element: any): void {
    console.log('details' + element.id);
  }

  public getStringAsHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }

}
