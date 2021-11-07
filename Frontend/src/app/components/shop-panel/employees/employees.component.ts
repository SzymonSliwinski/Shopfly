import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  tab: 'employees' | 'profiles' = 'employees';

  constructor() { }

  ngOnInit(): void {
  }

  public onTabChange(tab: 'employees' | 'profiles') {
    this.tab = tab;
    console.log(this.tab)
  }


}
