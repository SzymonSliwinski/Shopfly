import { NgModule } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { SignInComponent } from './sign-in/sign-in.component';

const routes: Routes = [
  {path:'panel/main', component: MainComponent, canActivate: [AuthenticationService]},
  {path:'panel/sign-in', component: SignInComponent}
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
