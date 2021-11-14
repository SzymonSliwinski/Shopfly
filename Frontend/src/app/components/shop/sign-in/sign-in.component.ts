import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationDto } from 'src/app/dto/authentication.dto';
import { ShopAuthenticationService } from 'src/app/services/shop/shop-authentication.service';
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
    private router: Router,
    private readonly _authService: ShopAuthenticationService
  ) { }

  ngOnInit() {
    this.redirectIfSignedIn();
  }

  redirectIfSignedIn(): void {
    if (sessionStorage.getItem(environment._shopStorageKey) !== null)
      this.router.navigate(['']);
  }

  async onSubmit() {
    if (this.form.invalid)
      return;

    let result = { email: this.email!.value, password: this.password!.value } as AuthenticationDto;
    let isSucceeded = await this._authService.authenticate(result);
    if (isSucceeded === true) {
      this.router.navigate(['']);
      this.wrongCredentialsError = false;
    }
    else {
      this.wrongCredentialsError = true
    }

  }
}
