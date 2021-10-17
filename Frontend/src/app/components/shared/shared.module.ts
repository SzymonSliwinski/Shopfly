import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelSubpageHeaderComponent } from './panel-subpage-header/panel-subpage-header.component';
import { MatIconModule } from '@angular/material/icon';
import { DataTableComponent } from './data-table/data-table.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    declarations: [
        PanelSubpageHeaderComponent,
        DataTableComponent,
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatTableModule
    ],
    providers: [
    ],
    exports: [
        PanelSubpageHeaderComponent,
        DataTableComponent
    ]
})

export class SharedModule { }
