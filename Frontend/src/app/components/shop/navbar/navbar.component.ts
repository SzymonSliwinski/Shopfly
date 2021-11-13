import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  displayNavbarContent = true;
  constructor(
    private readonly _router: Router
  ) {
    _router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.setVisibilityOfNavbar(val.url);
    });
  }

  setVisibilityOfNavbar(val: string): void {
    this.displayNavbarContent = val.includes('sign-in') || val.includes('sign-up') ? false : true;
  }

}
