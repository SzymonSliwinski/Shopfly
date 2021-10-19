import { Component, Input, OnInit } from '@angular/core';
import { TableColumnDto } from 'src/app/dto/table-column.dto';

@Component({
  selector: 'shared-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
})
export class DataTableComponent implements OnInit {
  @Input() dataSource!: any;
  @Input() displayedColumns!: TableColumnDto[];
  @Input() columnsNames!: string[];
  @Input() hasSelectableRows: boolean = false;

  constructor() { }

  ngOnInit() { }

}
