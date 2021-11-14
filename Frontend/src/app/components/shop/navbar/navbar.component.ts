import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { ShopAuthenticationService } from 'src/app/services/shop/shop-authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  @Input() isLogged = false;
  displayNavbarContent = true;
  @Output() toggleNavbarEventEmitter = new EventEmitter<boolean>();

  constructor(
    private readonly _router: Router,
    private readonly _authService: ShopAuthenticationService
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
