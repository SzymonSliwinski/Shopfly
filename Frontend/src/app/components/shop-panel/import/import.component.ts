import { Component, OnInit } from '@angular/core';
import { TableTypesStringList } from 'src/app/models/api-models/api-key-tables-methods.model';
@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {
  public tables!: string[]
  constructor() { }

  ngOnInit(): void {
    this.tables = this.getTablesAsString();
  }

  public getTablesAsString(): string[] {
    return TableTypesStringList();
  }
}
