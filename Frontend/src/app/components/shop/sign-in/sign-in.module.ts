import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInComponent } from './sign-in.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
@NgModule({
    declarations: [
        SignInComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        MatButtonModule,
        ReactiveFormsModule
    ],
    providers: [
    ],
    exports: [
        SignInComponent
    ]
})

export class SignInModule { }
