import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLogged = true;
  showCategories = true;
  @ViewChild('sidebar') sidebar!: SidebarComponent;

  constructor() { }

  ngOnInit(): void {
    this.isLogged = this.checkIsLogged();
  }

  checkIsLogged(): boolean {
    if (!sessionStorage.getItem(environment._shopStorageKey))
      return false;

    let storage =
      JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };

    if (new Date().getTime() > new Date(storage.token.expirationDate).getTime())
      return false;

    return true;
  }

  toggleCategories() {
    this.showCategories = !this.showCategories;
    this.showCategories === true ? this.sidebar.toggle() : this.sidebar.hide();
  }

}
