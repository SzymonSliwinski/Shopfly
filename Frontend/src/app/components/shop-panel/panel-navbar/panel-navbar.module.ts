import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelNavbarComponent } from './panel-navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
  declarations: [
    PanelNavbarComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatMenuModule
  ],
  providers: [

  ],
  exports: [
    PanelNavbarComponent,

  ]
})

export class PanelNavbarModule { }
