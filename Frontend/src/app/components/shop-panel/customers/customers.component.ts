import { Component, OnInit } from '@angular/core';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';
import { Customer } from '../../../models/shop-models/customer.model';
import { DatePipe } from '@angular/common';
import { CustomersService } from 'src/app/services/shop-panel-services/customers.service';
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  public productsList!: Customer[];
  public isChoosenElementVisible!: boolean;
  isLoaded = false;

  constructor(
    private readonly _customersService: CustomersService
  ) { }

  public tableButtons: TableButton[] = [];
  public menuButtons: MenuButton[] = [];
  public displayedColumns: TableColumnDto[] =
    [
      { title: 'ID', objectField: 'id' },
      { title: 'Name', objectField: 'name' },
      { title: 'Surname', objectField: 'surname' },
      { title: 'E-mail address', objectField: 'email' },
      { title: 'Newsletter', objectField: 'isNewsletterSubscribed', contentMode: ContentMode.TrueOrFalse },
      { title: 'Registration date', objectField: 'createDate', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }, contentMode: ContentMode.DynamicPipe },
      { title: 'Last login date', objectField: 'lastLoginDate', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }, contentMode: ContentMode.DynamicPipe },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  async ngOnInit(): Promise<void> {
    this.isLoaded = false;
    this.productsList = await this._customersService.getAll();

    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

}
