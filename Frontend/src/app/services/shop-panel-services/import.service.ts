import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiAccessKey } from 'src/app/models/api-models/api-access-key.model';
import { TableType } from 'src/app/models/api-models/api-key-tables-methods.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class ImportService {
    constructor(private _http: HttpClient) { }

    public async import(file: File, tableType: TableType): Promise<ApiAccessKey> {
        let formData = new FormData();
        formData.append('file', file, file.name);
        return this._http.post<ApiAccessKey>(environment._shopPanelApiUrl + `import/${tableType}`, formData).toPromise()
    }


}
