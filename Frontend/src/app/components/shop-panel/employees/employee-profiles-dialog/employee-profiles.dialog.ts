import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';
import { ProfileService } from 'src/app/services/shop-panel-services/profile.service';

@Component({
  selector: 'app-employee-profiles-dialog',
  templateUrl: './employee-profiles.dialog.html',
  styleUrls: ['./employee-profiles.dialog.scss']
})
export class EmployeeProfilesDialog implements OnInit {
  profilesList: Profile[] = [];
  isLoaded = false;
  constructor(
    private readonly _dialogRef: MatDialogRef<EmployeeProfilesDialog>,
    private readonly _profileService: ProfileService,
    @Inject(MAT_DIALOG_DATA) public employeeId: number,
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Delete];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Orders', objectField: 'hasAccessToOrders', contentMode: ContentMode.TrueOrFalse },
      { title: 'Products', objectField: 'hasAccessToProducts', contentMode: ContentMode.TrueOrFalse },
      { title: 'Customers', objectField: 'hasAccessToCustomers', contentMode: ContentMode.TrueOrFalse },
      { title: 'Charts', objectField: 'hasAccessToCharts', contentMode: ContentMode.TrueOrFalse },
      { title: 'Settings', objectField: 'hasAccessToSettings', contentMode: ContentMode.TrueOrFalse },
      { title: 'API', objectField: 'hasAccessToApi', contentMode: ContentMode.TrueOrFalse },
      { title: 'Employees', objectField: 'hasAccessToEmployees', contentMode: ContentMode.TrueOrFalse },
      { title: 'Imports', objectField: 'hasAccessToImports', contentMode: ContentMode.TrueOrFalse },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons }
    ];

  public columnsNames: string[] = [];
  ngOnInit(): void {
    this.refresh();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
  }

  async refresh(): Promise<void> {
    this.isLoaded = false;
    this.profilesList = await this._profileService.getProfilesForEmployee(this.employeeId);
    this.isLoaded = true;
  }

}
