import { NgModule } from '@angular/core';
import { AuthenticationService } from './../services/authentication.service';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
  {path:'main', component: MainComponent, canActivate: [AuthenticationService]}
];

@NgModule({
  declarations: [
    MainComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    AuthenticationService
  ],
  exports:[
    MainComponent,
    RouterModule
  ]
})

export class ShopPanelModule { }
