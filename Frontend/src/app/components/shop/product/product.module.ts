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
import { MatSelectModule } from '@angular/material/select';
import { ProductsService } from 'src/app/services/shop/product.service';
import { PaginatorModule } from 'primeng/paginator';
import { ProductComponent } from './product.component';
import { CommentsComponent } from './comments/comments.component';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
@NgModule({
    declarations: [
        ProductComponent,
        CommentsComponent
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
        PaginatorModule
    ],
    providers: [
        ProductsService,
        CustomerCartService,
        CustomerFavoritesProductsService
    ],
    exports: [
        ProductComponent
    ]
})

export class ProductModule { }