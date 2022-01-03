import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Profile } from 'src/app/models/shop-panel-models/profile.model';
import { ProfileService } from 'src/app/services/shop-panel-services/profile.service';
import { ProfileDialog } from '../profile-dialog/profile.dialog';

@Component({
  selector: 'app-profiles-list',
  templateUrl: './profiles-list.component.html',
  styleUrls: ['./profiles-list.component.scss']
})
export class ProfilesListComponent implements OnInit {
  public profilesList!: Profile[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    private readonly _profileService: ProfileService,
    public _dialog: MatDialog
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

  async ngOnInit(): Promise<void> {
    this.refresh();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
  }

  public async onDeleteClick(profile: Profile) {
    await this._profileService.delete(profile.id);
    this.profilesList = this.profilesList.filter(c => c.id !== profile.id);
  }

  public async onEditClick(profile: Profile) {
    const dialog = this._dialog.open(ProfileDialog, {
      data: profile
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    })
  }

  async refresh() {
    this.isLoaded = false;
    this.profilesList = await this._profileService.getAll();
    this.isLoaded = true;
  }
}
