import { Component, OnInit } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { ApiKeysTablesMethods, HttpMethodType, HttpMethodTypesStringList, HttpMethodTypeToEnum, HttpMethodTypeToString, TableTypesStringList } from 'src/app/models/api-models/api-key-tables-methods.model';
import { ApiService } from 'src/app/services/shop-panel-services/api.service';

@Component({
  selector: 'app-add-key',
  templateUrl: './add-key.component.html',
  styleUrls: ['./add-key.component.scss']
})
export class AddKeyComponent implements OnInit {
  apiAccessKey: ApiAccessKey = {} as ApiAccessKey;
  constructor(
    private readonly _apiService: ApiService
  ) { }

  ngOnInit(): void {
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

  onSaveClick() {
    if (this.apiAccessKey.apiKeysTablesMethods?.length === 0)
      return;
    if (this.apiAccessKey.key.length === 0) return;

    this._apiService.add(this.apiAccessKey);
  }
}
