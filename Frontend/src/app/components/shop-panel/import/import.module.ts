import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { ImportComponent } from './import.component';

@NgModule({
    declarations: [
        ImportComponent
    ],
    entryComponents: [
    ],
    imports: [
        CommonModule,
        MatIconModule,
    ],
    providers: [
    ],
    exports: [
        ImportComponent,
    ]
})

export class ImportModule { }
