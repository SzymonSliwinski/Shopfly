import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavoritesProductsComponent } from './favorites-products.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
@NgModule({
    declarations: [
        FavoritesProductsComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatCheckboxModule
    ],
    providers: [
    ],
    exports: [
        FavoritesProductsComponent
    ]
})

export class FavoritesProductsModule { }
