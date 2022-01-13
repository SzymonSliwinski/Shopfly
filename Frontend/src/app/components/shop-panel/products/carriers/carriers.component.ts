import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Carrier } from 'src/app/models/shop-models/carrier.model';
import { CarriersService } from 'src/app/services/shop-panel-services/carriers.service';
import { AddCarrierDialog } from './add-carrier/add-carrier.dialog';

@Component({
  selector: 'app-carriers',
  templateUrl: './carriers.component.html',
  styleUrls: ['./carriers.component.scss']
})
export class CarriersComponent implements OnInit {
  public carriersList!: Carrier[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    public _dialog: MatDialog,
    private readonly _carriersService: CarriersService
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Delete];
  public menuButtons: MenuButton[] = [];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Cost', objectField: 'cost' },
      { title: 'Delivery days min', objectField: 'deliveryDaysMinimum' },
      { title: 'Delivery days min', objectField: 'codeliveryDaysMaximum' },
      { title: 'isActive', objectField: 'isActive', contentMode: ContentMode.TrueOrFalse },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  async ngOnInit(): Promise<void> {
    this.refresh();
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
  }

  async refresh() {
    this.isLoaded = false;
    this.carriersList = await this._carriersService.getAll();
    this.isLoaded = true;
  }

  public async onDeleteClick(carrier: Carrier) {
    await this._carriersService.delete(carrier.id);
    this.carriersList = this.carriersList.filter(c => c.id !== carrier.id);
  }

  public async onEditClick(carrier: Carrier) {
    const dialog = this._dialog.open(AddCarrierDialog, {
      data: carrier
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    });
  }

}
