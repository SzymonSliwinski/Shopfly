import { Component, OnInit } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { ApiKeysTablesMethods, HttpMethodType, HttpMethodTypesStringList, HttpMethodTypeToEnum, HttpMethodTypeToString, TableTypesStringList } from 'src/app/models/api-models/api-key-tables-methods.model';
import { ApiService } from 'src/app/services/shop-panel-services/api.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-key',
  templateUrl: './add-key.component.html',
  styleUrls: ['./add-key.component.scss']
})
export class AddKeyComponent implements OnInit {
  apiAccessKey: ApiAccessKey = {} as ApiAccessKey;
  public isEditForm: boolean = false;
  private editKey?: string;
  constructor(
    private readonly _apiService: ApiService,
    private readonly _location: Location,
    private readonly _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar

  ) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(async param => {
      if (param['key']) {
        this.editKey = param['key'].toString();
        this.isEditForm = true;
        this.apiAccessKey = await this._apiService.getFullByKey(this.editKey!);
      }
    });

    this.apiAccessKey.apiKeysTablesMethods = [];
    this.apiAccessKey.createDate = new Date();
  }

  onRandomKeyClick() {
    this.apiAccessKey.key = this.getRandomKey();
  }

  private getRandomKey(): string {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+';
    var charactersLength = characters.length;
    for (var i = 0; i < 50; i++) {
      result += characters.charAt(Math.floor(Math.random() *
        charactersLength));
    }
    return result;
  }

  public getTableTypesStringList(): string[] {
    return TableTypesStringList();
  }

  public getHttpMethodTypesStringList(): string[] {
    return HttpMethodTypesStringList();
  }

  public httpMethodTypeToString(type: HttpMethodType): string {
    return HttpMethodTypeToString(type);
  }

  public httpMethodTypeToEnum(type: string): HttpMethodType {
    return HttpMethodTypeToEnum(type)!;
  }

  public onPropertyChange(tableNumber: number, methodNumber: number): void {
    let index = this.apiAccessKey.apiKeysTablesMethods!.findIndex(x => x.table == tableNumber && x.httpMethod == methodNumber);

    if (index !== -1) { // findIndex returns -1 if element not found
      this.apiAccessKey.apiKeysTablesMethods!.splice(index, 1);
      return;
    }

    this.apiAccessKey.apiKeysTablesMethods!.push({
      table: tableNumber,
      httpMethod: methodNumber
    } as ApiKeysTablesMethods);
  }

  public shouldBeChecked(tableNumber: number, methodNumber: number): boolean {
    if (!this.isEditForm)
      return false;
    let keyFound = this.apiAccessKey.apiKeysTablesMethods!.find(c => c.httpMethod == methodNumber && c.table == tableNumber);
    if (!keyFound)
      return false;
    return true;
  }

  async onSaveClick() {
    if (this.isEditForm) {
      await this._apiService.update(this.apiAccessKey);
      this._snackBar.open("Saved!", "OK", { duration: 5000 });
      return;
    }

    if (this.apiAccessKey.apiKeysTablesMethods?.length === 0) return;
    if (this.apiAccessKey.key.length === 0) return;
    if (await this._apiService.doesKeyExist(this.apiAccessKey.key)) return;

    if (!this.isEditForm)
      await this._apiService.add(this.apiAccessKey);
    this._snackBar.open("Saved!", "OK", { duration: 5000 });

  }

  back() {
    this._location.back();
  }
}
