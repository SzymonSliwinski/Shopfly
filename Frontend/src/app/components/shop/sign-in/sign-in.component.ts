import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationDto } from 'src/app/dto/authentication.dto';
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
  ) { }

  ngOnInit() {
    this.redirectIfSignedIn();
  }

  redirectIfSignedIn(): void {

  }

  async onSubmit() {


  }
}
