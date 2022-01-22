import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavoritesProductsComponent } from './favorites-products.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDividerModule } from '@angular/material/divider';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
@NgModule({
    declarations: [
        FavoritesProductsComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatCheckboxModule,
        MatDividerModule
    ],
    providers: [
        CustomerFavoritesProductsService
    ],
    exports: [
        FavoritesProductsComponent
    ]
})

export class FavoritesProductsModule { }
