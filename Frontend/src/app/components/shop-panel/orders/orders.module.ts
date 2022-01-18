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
import { OrderService } from 'src/app/services/shared/orders.service';
import { MatDialogModule } from '@angular/material/dialog';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { StatusService } from 'src/app/services/shared/status.service';
import { MatRadioModule } from '@angular/material/radio';
import { OrdersService } from 'src/app/services/shop-panel-services/orders.service';

@NgModule({
  declarations: [
    OrdersComponent,
    ChangeStatusDialogComponent
  ],
  entryComponents: [

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
    MatDialogModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatRadioModule
  ],
  providers: [
    OrderService,
    StatusService,
    OrdersService
  ],
  exports: [
    OrdersComponent,
  ]
})

export class OrdersModule { }
