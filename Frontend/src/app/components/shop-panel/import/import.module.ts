import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { ImportComponent } from './import.component';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ImportService } from 'src/app/services/shop-panel-services/import.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';

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
        MatButtonModule,
        MatSnackBarModule
    ],
    providers: [
        ImportService
    ],
    exports: [
        ImportComponent,
    ]
})

export class ImportModule { }
