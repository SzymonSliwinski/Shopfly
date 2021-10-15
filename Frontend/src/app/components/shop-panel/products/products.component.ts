import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/shop-models/product.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  public productsList!: Product[];
  public displayedColumns: string[] = ['id', 'photo', 'name', 'category', 'nettoPrice', 'bruttoPrice', 'isVisible', 'quantity', 'buttons'];
  public isChoosenElementVisible!: boolean;
  constructor() { }

  ngOnInit(): void {
    this.productsList = [{
      id: 1,
      name: 'produkt1 produkt1 produkt1 123',
      taxId: 0,
      isLowStock: false,
      additionalShippingCost: 0,
      nettoPrice: 123,
      bruttoPrice: 123.33,
      createDate: new Date(),
      isActive: true,
      isVisible: true,
      updateDate: new Date(),
      description: 'smieszny opis',
      categoryId: 1,
      category: { id: 1, parentCategory: null, name: 'kategoria', isRoot: false, parentCategoryId: 0, position: 1, childrensCategories: [], products: [] },
      tax: null,
      comments: null,
      ordersProducts: null,
      productsPayments: null,
      clientFavouritesProducts: null,
      productsCarriers: null,
      ratings: null,
      productsTags: null,
      productsVariants: null
    }, {
      id: 2,
      name: 'produkt2 123',
      taxId: 0,
      isLowStock: false,
      additionalShippingCost: 0,
      nettoPrice: 321,
      bruttoPrice: 321.33,
      createDate: new Date(),
      isActive: true,
      isVisible: false,
      updateDate: new Date(),
      description: 'smieszny opis2',
      categoryId: 1,
      category: { id: 1, parentCategory: null, name: 'kategoria', isRoot: false, parentCategoryId: 0, position: 1, childrensCategories: [], products: [] },
      tax: null,
      comments: null,
      ordersProducts: null,
      productsPayments: null,
      clientFavouritesProducts: null,
      productsCarriers: null,
      ratings: null,
      productsTags: null,
      productsVariants: null
    }
    ];
  }

  public onElementMenuExtend(element: Product) {
    this.isChoosenElementVisible = element.isVisible;
  }
}