import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { CartProductsListComponent } from './cart-products-list/cart-products-list.component';

@NgModule({
    declarations: [
        CartComponent,
        CartProductsListComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatStepperModule
    ],
    providers: [
    ],
    exports: [
    ]
})

export class CartModule { }
