import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SignInComponent } from './sign-in/sign-in.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    SignInComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
  ],
  providers: [],
  exports:[
    SignInComponent,
  ]
})

export class FormModule { }
