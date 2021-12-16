import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatChipsModule } from '@angular/material/chips';
import { ProductsComponent } from './products.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { ProductsService } from 'src/app/services/shop-panel-services/products.service';

@NgModule({
    declarations: [
        ProductsComponent,
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatMenuModule,
        MatTableModule,
        MatButtonModule,
        MatPaginatorModule,
        MatChipsModule,
        MatFormFieldModule,
        SharedModule,
        MatSelectModule,
        MatCheckboxModule,
        FormsModule,
        MatInputModule
    ],
    providers: [
        ProductsService
    ],
    exports: [
        ProductsComponent,
    ]
})

export class ProductsModule { }