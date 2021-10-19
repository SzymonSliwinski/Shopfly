import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { OrdersComponent } from './orders.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatChipsModule } from '@angular/material/chips';
import { SharedModule } from '../../shared/shared.module';
import { TableButtonsComponent } from './table-buttons.component';

@NgModule({
  declarations: [
    OrdersComponent,
    TableButtonsComponent,
  ],
  entryComponents: [
    TableButtonsComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatMenuModule,
    MatTableModule,
    MatButtonModule,
    MatPaginatorModule,
    MatChipsModule,
    SharedModule,
  ],
  providers: [
  ],
  exports: [
    OrdersComponent,
  ]
})

export class OrdersModule { }
