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
        MatFormFieldModule
    ],
    providers: [
    ],
    exports: [
        ProductsComponent,
    ]
})

export class ProductsModule { }