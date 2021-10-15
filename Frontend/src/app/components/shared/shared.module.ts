import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelSubpageHeaderComponent } from './panel-subpage-header/panel-subpage-header.component';
import { MatIconModule } from '@angular/material/icon';
@NgModule({
    declarations: [
        PanelSubpageHeaderComponent,
    ],
    imports: [
        CommonModule,
        MatIconModule
    ],
    providers: [
    ],
    exports: [
        PanelSubpageHeaderComponent
    ]
})

export class SharedModule { }
