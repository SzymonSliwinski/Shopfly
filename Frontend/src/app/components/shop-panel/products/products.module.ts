import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatChipsModule } from '@angular/material/chips';
import { ProductsComponent } from './products.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { ProductsService } from 'src/app/services/shop-panel-services/products.service';
import { CategoriesComponent } from './categories/categories.component';
import { MatTabsModule } from '@angular/material/tabs';
import { AddCategoryDialog } from './categories/add-category/add-category.dialog';
import { CategoriesService } from 'src/app/services/shop-panel-services/categories.service';
import { ListsComponent } from './lists/lists.component';
import { CarriersComponent } from './carriers/carriers.component';
import { AddCarrierDialog } from './carriers/add-carrier/add-carrier.dialog';
import { CarriersService } from 'src/app/services/shop-panel-services/carriers.service';
import { AddListsDialog } from './lists/add-lists/add-lists.dialog';
import { ListsService } from 'src/app/services/shop-panel-services/lists.service';

@NgModule({
    declarations: [
        ProductsComponent,
        CategoriesComponent,
        AddCategoryDialog,
        ListsComponent,
        CarriersComponent,
        AddCarrierDialog,
        AddListsDialog,
    ],
    imports: [
        CommonModule,
        MatIconModule,
        MatMenuModule,
        MatTableModule,
        MatButtonModule,
        MatPaginatorModule,
        MatChipsModule,
        MatFormFieldModule,
        SharedModule,
        MatSelectModule,
        MatCheckboxModule,
        FormsModule,
        MatInputModule,
        MatTabsModule
    ],
    providers: [
        ProductsService,
        CategoriesService,
        CarriersService,
        ListsService
    ],
    exports: [
        ProductsComponent,
    ]
})

export class ProductsModule { }