import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelNavbarComponent } from './panel-navbar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';

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
    PanelAuthenticationService
  ],
  exports: [
    PanelNavbarComponent,
  ]
})

export class PanelNavbarModule { }
