import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from '../../services/authentication.service';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
  ],
  providers: [
    AuthenticationService
  ],
  exports:[]
})

export class ShopModule { }
