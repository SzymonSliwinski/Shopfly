import { Component, OnInit } from '@angular/core';
import { MenuButton, TableButton } from 'src/app/components/shared/data-table/data-table.component';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { Employee } from 'src/app/models/shop-panel-models/employee.model';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  public employeesList!: Employee[];

  public isChoosenElementVisible!: boolean;
  isLoaded = false;
  constructor() { }
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

  ngOnInit(): void {
    this.isLoaded = false;
    this.employeesList = [{
      id: 1,
      name: 'Jan',
      surname: 'Kalewicz',
      email: 'Jan@Kalewicz.pl',
      isActive: true,
    },
    {
      id: 2,
      name: 'Ździsław',
      surname: 'Broniewski',
      email: 'zdzich@bron.pl',
      isActive: true,
    }];
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }
}
