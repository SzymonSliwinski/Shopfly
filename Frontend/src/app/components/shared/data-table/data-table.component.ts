import { Component, Input } from '@angular/core';
import { TableColumnDto } from 'src/app/dto/table-column.dto';

@Component({
  selector: 'shared-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent {
  @Input() dataSource: any;
  @Input() displayedColumns!: TableColumnDto[];
  @Input() columnsNames!: string[];



}
