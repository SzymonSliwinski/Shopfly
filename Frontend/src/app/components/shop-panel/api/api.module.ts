import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { ApiComponent } from './api.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { SharedModule } from '../../shared/shared.module';
import { AddKeyComponent } from './add-key/add-key.component';
import { RouterModule } from '@angular/router';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ApiService } from 'src/app/services/shop-panel-services/api.service';

@NgModule({
    declarations: [
        ApiComponent,
        AddKeyComponent
    ],
    entryComponents: [
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatMenuModule,
        MatTableModule,
        MatButtonModule,
        MatSlideToggleModule,
        FormsModule,
        MatListModule,
        MatSelectModule,
        MatFormFieldModule,
        MatInputModule,
        SharedModule,
        RouterModule,
        MatCheckboxModule
    ],
    providers: [
        ApiService
    ],
    exports: [
        ApiComponent,
    ]
})

export class ApiModule { }
