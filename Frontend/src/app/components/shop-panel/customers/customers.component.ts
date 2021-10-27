import { Component, OnInit } from '@angular/core';
import { ContentMode, TableColumnDto } from 'src/app/dto/table-column.dto';
import { MenuButton, TableButton } from '../../shared/data-table/data-table.component';
import { Customer } from '../../../models/shop-models/customer.model';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {
  public productsList!: Customer[];
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
      { title: 'Newsletter', objectField: 'isNewsletterSubscribed', contentMode: ContentMode.TrueOrFalse },
      { title: 'Active account', objectField: 'isActive', contentMode: ContentMode.TrueOrFalse },
      { title: 'Registration date', objectField: 'createDate', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }, contentMode: ContentMode.DynamicPipe },
      { title: 'Last login date', objectField: 'lastLoginDate', pipeValues: { pipe: DatePipe, pipeArgs: 'dd-MM-yyyy HH:mm' }, contentMode: ContentMode.DynamicPipe },
      { title: '', objectField: 'buttons', contentMode: ContentMode.Buttons },
    ];
  public columnsNames: string[] = [];

  ngOnInit(): void {
    this.isLoaded = false;
    this.productsList = [{
      id: 1,
      name: 'Jan',
      surname: 'Kalewicz',
      email: 'Jan@Kalewicz.pl',
      isNewsletterSubscribed: true,
      isActive: true,
      createDate: new Date(),
      lastLoginDate: new Date()
    },
    {
      id: 2,
      name: 'Ździsław',
      surname: 'Broniewski',
      email: 'zdzich@bron.pl',
      isNewsletterSubscribed: false,
      isActive: true,
      createDate: new Date(),
      lastLoginDate: new Date()
    }];
    this.displayedColumns.forEach(c => {
      this.columnsNames.push(c.objectField!);
    });
    this.isLoaded = true;
  }

}
