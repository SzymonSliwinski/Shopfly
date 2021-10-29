import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { ShopSettingsComponent } from './shop-settings.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
    declarations: [
        ShopSettingsComponent
    ],
    entryComponents: [

    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatMenuModule,
        MatTableModule,
        MatButtonModule,

    ],
    providers: [
    ],
    exports: [
        ShopSettingsComponent,
    ]
})

export class ShopSettingsModule { }
