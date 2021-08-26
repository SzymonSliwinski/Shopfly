import { FormModule } from './../../../forms/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    MainComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FormModule
  ],
  providers: [
    
  ],
  exports:[
    MainComponent,
  ]
})

export class MainModule { }
