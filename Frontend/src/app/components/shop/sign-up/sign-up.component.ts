import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/models/shop-models/customer.model';
import { CustomerService } from 'src/app/services/shop/customer-service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  newCustomer: Customer = {} as Customer;
  didUserAgreed = false;
  constructor(
    private readonly _customerService: CustomerService,
    private _router: Router
  ) { }

  ngOnInit(): void {

  }

  async onSaveClick() {
    if (!this.didUserAgreed)
      return;
    if (!this.newCustomer.email || !this.newCustomer.password)
      return;
    await this._customerService.add(this.newCustomer);
    this._router.navigate(['']);

  }

}
