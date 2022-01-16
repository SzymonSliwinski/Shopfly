import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { CustomerService } from 'src/app/services/shop/customer-service';
import { ShopAuthenticationService } from 'src/app/services/shop/shop-authentication.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  isLogged = false;
  displayNavbarContent = true;
  @Output() toggleNavbarEventEmitter = new EventEmitter<boolean>();
  customerName!: string;

  async ngOnInit(): Promise<void> {
    if (sessionStorage[environment._shopStorageKey]) {
      this.isLogged = true;
      const customer = await this._customerService.getById(JSON.parse((sessionStorage[environment._shopStorageKey])).token.userId)
      this.customerName = customer.name;
    }
  }

  constructor(
    private readonly _router: Router,
    private readonly _authService: ShopAuthenticationService,
    private readonly _customerService: CustomerService
  ) {
    _router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.setVisibilityOfNavbar(val.url);
    });
  }

  setVisibilityOfNavbar(val: string): void {
    this.displayNavbarContent = val.includes('sign-in') || val.includes('sign-up') ? false : true;
  }

  public async onLogoutClick(): Promise<boolean> {
    await this._authService.logout();
    return this._router.navigate(['sign-in']);
  }

  onMenuClick() {
    this.toggleNavbarEventEmitter.emit(true);
  }
}
