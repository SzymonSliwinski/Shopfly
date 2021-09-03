import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationDto } from 'src/app/dto/authentication.dto';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  public form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });
  wrongCredentialsError: boolean = false
  get email() { return this.form.get('email'); }
  get password() { return this.form.get('password'); }

  constructor(
    private readonly _panelAuthService: PanelAuthenticationService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.redirectIfSignedIn();
    console.log("jestem tu")
  }

  redirectIfSignedIn(): void {
    if (localStorage.getItem(environment._panelStorageKey) !== null)
      this.router.navigate(['panel/dashboard']);
  }

  async onSubmit() {
    if (this.form.invalid)
      return;

    let result = { loginOrEmail: this.email!.value, password: this.password!.value } as AuthenticationDto;
    let isSucceeded = await this._panelAuthService.authenticate(result);
    if (isSucceeded === true) {
      this.router.navigate(['panel/dashboard']);
      this.wrongCredentialsError = false;
    }
    else {
      this.wrongCredentialsError = true
    }

  }

}
