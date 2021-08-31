import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelNavbarComponent } from './panel-navbar.component';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [
    PanelNavbarComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
  ],
  providers: [
    
  ],
  exports:[
    PanelNavbarComponent,

  ]
})

export class PanelNavbarModule { }
