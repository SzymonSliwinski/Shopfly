import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

export enum Tabs {
  Dashboard,
  Orders,
  Products,
  Customers,
  Charts,
  Settings,
  Api,
  Employees,
  Import
}

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  activeTab!: Tabs;
  tabs = Tabs;
  constructor(
    private readonly _router: Router
  ) {
    _router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.setActiveTab(val.url);
    });
  }

  setActiveTab(val: string): void {
    if (val.includes('dashboard'))
      this.activeTab = Tabs.Dashboard;

    else if (val.includes('orders'))
      this.activeTab = Tabs.Orders;

    else if (val.includes('products'))
      this.activeTab = Tabs.Products;

    else if (val.includes('customers'))
      this.activeTab = Tabs.Customers;

    else if (val.includes('charts'))
      this.activeTab = Tabs.Charts;

    else if (val.includes('settings'))
      this.activeTab = Tabs.Settings;

    else if (val.includes('api'))
      this.activeTab = Tabs.Api;

    else if (val.includes('employees'))
      this.activeTab = Tabs.Employees;

    else if (val.includes('import'))
      this.activeTab = Tabs.Import;
  }
}