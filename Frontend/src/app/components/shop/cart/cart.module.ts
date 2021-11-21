import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart.component';
import { MatButtonModule } from '@angular/material/button';
@NgModule({
    declarations: [
        CartComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
    ],
    providers: [
    ],
    exports: [
    ]
})

export class CartModule { }
