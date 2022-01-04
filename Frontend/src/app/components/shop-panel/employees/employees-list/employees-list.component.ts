import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';
import { EmployeeService } from 'src/app/services/shop-panel-services/employee.service';
import { EmployeeDialog } from '../employee-dialog/employee.dialog';
import { EmployeeProfilesDialog } from '../employee-profiles-dialog/employee-profiles.dialog';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  public employeesList!: Employee[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    private readonly _employeeService: EmployeeService,
    public _dialog: MatDialog
  ) { }

  public tableButtons: TableButton[] = [TableButton.Edit, TableButton.Menu];
  public menuButtons: MenuButton[] = [MenuButton.Delete, MenuButton.Details];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Surname', objectField: 'surname' },
      { title: 'E-mail address', objectField: 'email' },
      { title: 'Active', objectField: 'isActive', contentMode: ContentMode.TrueOrFalse },
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
    this.employeesList = await this._employeeService.getAll();
    this.isLoaded = true;
  }

  public async onDeleteClick(employee: Employee) {
    await this._employeeService.delete(employee.id);
    this.employeesList = this.employeesList.filter(c => c.id !== employee.id);
  }

  public async onEditClick(employee: Employee) {
    const dialog = this._dialog.open(EmployeeDialog, {
      data: employee
    });

    dialog.afterClosed().subscribe(() => {
      this.refresh();
    });
  }

  public async onViewClick(employee: Employee) {
    this._dialog.open(EmployeeProfilesDialog, {
      data: employee.id,
      width: "100%"
    })
  }
}
