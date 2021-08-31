import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PanelNavbarModule } from './panel-navbar/panel-navbar.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    MainComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PanelNavbarModule,
    MatDividerModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
  ],
  providers: [

  ],
  exports: [
    MainComponent,
  ]
})

export class MainModule { }
