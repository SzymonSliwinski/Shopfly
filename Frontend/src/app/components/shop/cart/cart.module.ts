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
import { OrderDetailsComponent } from './order-details/order-details.component';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { SummaryComponent } from './summary/summary.component';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CarriersService } from 'src/app/services/shop/carriers.service';
import { OrdersService } from 'src/app/services/shop/orders.service';

@NgModule({
    declarations: [
        CartComponent,
        CartProductsListComponent,
        OrderDetailsComponent,
        SummaryComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatIconModule,
        MatDividerModule,
        FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatStepperModule,
        MatRadioModule,
        MatCheckboxModule
    ],
    providers: [
        CustomerCartService,
        CarriersService,
        OrdersService
    ],
    exports: [
    ]
})

export class CartModule { }
