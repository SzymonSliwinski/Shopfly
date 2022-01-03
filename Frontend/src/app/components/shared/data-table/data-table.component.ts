import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
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
  @Input() hasSelectableRows: boolean = false;
  @Input() buttons: TableButton[] = [];
  @Input() menuButtons: MenuButton[] = [];
  @Input() data: any;
  contentMode = ContentMode;
  optionTemplateRef!: TemplateRef<any>;
  tableButton = TableButton;
  menuButton = MenuButton;
  public afterMenuClickedElement: any;
  public clickedMenuElement?: T;
  private selectedElements: T[] = [];
  //events
  @Output() public deleteEvent = new EventEmitter<T>();
  @Output() public editEvent = new EventEmitter<T>();
  @Output() public detailsEvent = new EventEmitter<T>();

  constructor(private readonly _sanitizer: DomSanitizer) { }

  public onDeleteClick(element: T): void {
    this.deleteEvent.emit(element);
  }

  public onEditClick(element: T) {
    this.editEvent.emit(element);
  }

  public onDetailsClick(element: T): void {
    this.detailsEvent.emit(element)
  }

  public getStringAsHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }

  public onMenuClick(element: T) {
    this.clickedMenuElement = element;
  }

  onCheckboxChange(element: any) {
    const elementString = JSON.stringify(element);
    if (this.selectedElements.find(c => JSON.stringify(c) === elementString)) {
      this.selectedElements = this.selectedElements.filter(c => JSON.stringify(c) !== elementString);
    } else {
      this.selectedElements.push(element);
    }
  }
}
