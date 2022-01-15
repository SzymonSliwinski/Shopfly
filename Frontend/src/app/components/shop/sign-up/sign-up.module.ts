import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignUpComponent } from './sign-up.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { CustomerService } from 'src/app/services/shop/customer-service';
import { FormsModule } from '@angular/forms';
@NgModule({
    declarations: [
        SignUpComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatCheckboxModule,
        FormsModule
    ],
    providers: [
        CustomerService
    ],
    exports: [
        SignUpComponent
    ]
})

export class SignUpModule { }
