import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ProductsPageComponent } from './products-page.component';
import { MatSelectModule } from '@angular/material/select';
import { CardModule } from 'primeng/card';
import { ProductsService } from 'src/app/services/shop/product.service';
import { PaginatorModule } from 'primeng/paginator';

@NgModule({
    declarations: [
        ProductsPageComponent
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatRadioModule,
        MatCheckboxModule,
        MatSelectModule,
        CardModule,
        PaginatorModule
    ],
    providers: [
        ProductsService
    ],
    exports: [
        ProductsPageComponent
    ]
})

export class ProductsPageModule { }
