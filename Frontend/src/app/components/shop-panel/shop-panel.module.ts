import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../services/authentication.service';
import { MainModule } from './main/main.module';
import { PanelRoutingModule } from './panel-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';

@NgModule({
  declarations: [
    SignInComponent
  ],
  imports: [
    CommonModule,
  ],
  providers: [
    AuthenticationService
  ],
  exports:[
    SignInComponent,
    MainModule,
    PanelRoutingModule,
  ]
})

export class ShopPanelModule { }
