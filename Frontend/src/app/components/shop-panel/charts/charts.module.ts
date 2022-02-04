import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ChartsComponent } from './charts.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ChartModule } from 'primeng/chart';
import { ChartService } from 'src/app/services/shop-panel-services/profile.service copy';

@NgModule({
    declarations: [
        ChartsComponent
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
        MatDatepickerModule,
        MatNativeDateModule,
        ChartModule
    ],
    providers: [
        ChartService
    ],
    exports: [
        ChartsComponent,
    ]
})

export class ChartsModule { }
