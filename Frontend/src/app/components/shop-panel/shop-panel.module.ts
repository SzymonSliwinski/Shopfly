import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../services/authentication.service';
import { MainModule } from './main/main.module';
import { PanelRoutingModule } from './panel-routing.module';
import { PanelSignInComponent } from './panel-sign-in/panel-sign-in.component';

@NgModule({
  declarations: [
    PanelSignInComponent
  ],
  imports: [
    CommonModule,
  ],
  providers: [
    AuthenticationService
  ],
  exports:[
    PanelSignInComponent,
    MainModule,
    PanelRoutingModule,
  ]
})

export class ShopPanelModule { }
