import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TableTypesStringList, TableTypeToEnum } from 'src/app/models/api-models/api-key-tables-methods.model';
import { ImportService } from 'src/app/services/shop-panel-services/import.service';
@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {
  public tables!: string[];
  isFileLoaded = false;
  public selectedTable?: string;
  file: File | undefined = undefined;
  constructor(
    private readonly _importService: ImportService,
    private _snackBar: MatSnackBar

  ) { }

  ngOnInit(): void {
    this.tables = this.getTablesAsString();
  }

  public getTablesAsString(): string[] {
    return TableTypesStringList();
  }

  public async onSaveClick() {
    if (!this.selectedTable)
      return;
    if (!this.file)
      return;

    await this._importService.import(this.file!, TableTypeToEnum(this.selectedTable!)!);
    this._snackBar.open("Saved!", "OK", { duration: 5000 });
    this.file = undefined;
    this.isFileLoaded = false;
    this.selectedTable = '';
  }

  public async onFileUpload(file: any) {
    this.file = file.target.files.item(0);
    if (file)
      this.isFileLoaded = true;
  }
}
