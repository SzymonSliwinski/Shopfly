import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationDto } from 'src/app/dto/authentication.dto';
import { PanelAuthenticationService } from 'src/app/services/shop-panel-services/panel-authentication.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
  public form: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  get email() { return this.form.get('email'); }
  get password() { return this.form.get('password'); }

  constructor(
    private readonly _panelAuthService: PanelAuthenticationService,
  ) { }

  async onSubmit() {
    if (this.form.invalid)
      return;

    let result = { loginOrEmail: this.email!.value, password: this.password!.value } as AuthenticationDto;
    console.log(await this._panelAuthService.authenticate(result));
  }

}
