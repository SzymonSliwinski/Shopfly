import { Component, OnInit } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { HttpMethodType, HttpMethodTypesStringList, HttpMethodTypeToEnum, HttpMethodTypeToString, TableTypesStringList } from 'src/app/models/api-models/api-key-tables-methods.model';

@Component({
  selector: 'app-add-key',
  templateUrl: './add-key.component.html',
  styleUrls: ['./add-key.component.scss']
})
export class AddKeyComponent implements OnInit {
  apiAccessKey: ApiAccessKey = {} as ApiAccessKey;
  constructor() { }

  ngOnInit(): void {
  }

  onRandomKeyClick() {
    this.apiAccessKey.key = this.getRandomKey();
  }

  private getRandomKey(): string {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
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
}
