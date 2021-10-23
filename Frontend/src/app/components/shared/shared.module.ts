import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelSubpageHeaderComponent } from './panel-subpage-header/panel-subpage-header.component';
import { MatIconModule } from '@angular/material/icon';
import { DataTableComponent } from './data-table/data-table.component';
import { MatTableModule } from '@angular/material/table';
import { DynamicPipe } from './dynamic-pipe.pipe';
import { MatButtonModule } from '@angular/material/button';
import { PortalModule } from '@angular/cdk/portal';

@NgModule({
    declarations: [
        PanelSubpageHeaderComponent,
        DataTableComponent,
        DynamicPipe,
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatTableModule,
        MatButtonModule,
        PortalModule
    ],
    providers: [

    ],
    exports: [
        PanelSubpageHeaderComponent,
        DataTableComponent,
        DynamicPipe
    ]
})

export class SharedModule { }
