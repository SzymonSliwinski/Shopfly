import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { ImportComponent } from './import.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
    declarations: [
        ImportComponent
    ],
    entryComponents: [
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatSelectModule,
        MatFormFieldModule,
        FormsModule,
        MatInputModule,
        MatButtonModule
    ],
    providers: [
    ],
    exports: [
        ImportComponent,
    ]
})

export class ImportModule { }
