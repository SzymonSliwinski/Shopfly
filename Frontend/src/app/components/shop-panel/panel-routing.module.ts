import { SignInComponent } from './../../forms/sign-in/sign-in.component';
import { NgModule } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {path:'panel/main', component: MainComponent, canActivate: [AuthenticationService]},
  {path:'panel/sign-in', component: SignInComponent, canActivate: [AuthenticationService]}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    AuthenticationService
  ],
  exports:[
    RouterModule,
  ]
})

export class PanelRoutingModule { }
