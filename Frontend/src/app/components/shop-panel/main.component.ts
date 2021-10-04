import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  constructor() {
    var values = localStorage.getItem(environment._panelStorageKey)!;
    console.log(values);
    // values.forEach(function (value: any, key: any) {
    //   console.log(key + " " + value)
    // });
  }
}