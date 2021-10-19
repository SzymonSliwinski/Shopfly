import { Component } from '@angular/core';

@Component({
    selector: 'order-table-buttons',
    template: `
    <button mat-button mat-icon-button>
        <mat-icon mat-icon style="color: rgb(133, 77, 14)">description</mat-icon>
    </button>
    <button class="mat-icon-button" mat-icon-button>
     <mat-icon mat-icon class="mat-icon" style="color: red">delete</mat-icon>
    </button>
    <button mat-stroked-button>Details</button>`
})
export class TableButtonsComponent {
}
