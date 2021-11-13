import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignUpComponent } from './sign-up.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
@NgModule({
    declarations: [
        SignUpComponent,
    ],
    imports: [
        CommonModule,
        MatButtonModule,
        MatCheckboxModule
    ],
    providers: [
    ],
    exports: [
        SignUpComponent
    ]
})

export class SignUpModule { }
