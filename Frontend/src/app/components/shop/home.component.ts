import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Category } from 'src/app/models/shop-models/category.model';
import { NavigationEnd, Router } from '@angular/router';
import { HomeProductsList } from 'src/app/models/shop-models/home-products-lists.model';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
interface Node {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLogged = true;
  showCategories = false;
  isLoaded = false;
  animateSidebar = false;
  isHomeSite = false;
  productsLists: HomeList[] = [
    {
      id: 1,
      title: 'On sale',
      url: '#',
      isVisible: true,
      homeProductsLists: [
        {
          productId: 1,
          listId: 1,
          product: {
            id: 1,
            categoryId: 1,
            name: 'prod1',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 754.51,
            bruttoPrice: 590.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.Ut esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/1077/200/300.jpg?hmac=BqQneQETTwZkHqmZmg4VxHsD-Lia-Qxp6nXv0c2eaac'
                    }
                  }
                ]
              }
            ]
          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              }
            ]
          }
        },
        {
          productId: 1,
          listId: 1,
          product: {
            id: 1,
            categoryId: 1,
            name: 'prod1',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 754.51,
            bruttoPrice: 590.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.Ut esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/1077/200/300.jpg?hmac=BqQneQETTwZkHqmZmg4VxHsD-Lia-Qxp6nXv0c2eaac'
                    }
                  }
                ]
              }
            ]

          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              }
            ]
          }
        }
      ]
    },
    {
      id: 1,
      title: 'Bestsellers',
      url: '#',
      isVisible: true,
      homeProductsLists: [
        {
          productId: 1,
          listId: 1,
          product: {
            id: 1,
            categoryId: 1,
            name: 'prod1',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 754.51,
            bruttoPrice: 590.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/1077/200/300.jpg?hmac=BqQneQETTwZkHqmZmg4VxHsD-Lia-Qxp6nXv0c2eaac'
                    }
                  }
                ]
              }
            ]
          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              },
            ]
          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              },
            ]
          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              },
            ]
          }
        },
        {
          productId: 2,
          listId: 1,
          product: {
            id: 2,
            categoryId: 1,
            name: 'prod2',
            isLowStock: false,
            additionalShippingCost: 27.05,
            nettoPrice: 123.51,
            bruttoPrice: 434.0,
            createDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            isActive: false,
            isVisible: false,
            updateDate: new Date('2021-06-05T18:25:23.1810916+02:00'),
            description: "Sed maxime ex.\nUt esse ut quia sed.",
            productsVariants: [
              {
                id: 1,
                price: 754.51,
                productsVariantsPhotos: [
                  {
                    productVariantId: 1,
                    photoId: 1,
                    photo: {
                      id: 1,
                      isCover: true,
                      path: 'https://i.picsum.photos/id/385/200/300.jpg?hmac=IG8cHDliDmlgbSYX1yquX_5cAHcuS_O378oPs5rZGrU'
                    }
                  }
                ]
              },
            ]
          }
        }
      ]
    }
  ];
  treeControl = new FlatTreeControl<Node>(
    node => node.level,
    node => node.expandable,
  );
  hasChild = (_: number, node: Node) => node.expandable;

  private _transformer = (node: Category, level: number) => {
    return {
      expandable: !!node.childrensCategories && node.childrensCategories.length > 0,
      name: node.name,
      level: level,
    };
  };

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.childrensCategories,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
  @ViewChild('sidebar') sidebar!: SidebarComponent;

  constructor(
    private readonly _router: Router
  ) {
    this.dataSource.data;
    _router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.isHomeSite = val.url === '/' ? true : false;
    });
  }

  ngOnInit(): void {
    this.isLogged = this.checkIsLogged();
    this.dataSource.data = [
      {
        id: 1, name: 'kategoria 1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories:
          [
            {
              id: 2, name: 'kategoria 1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                { id: 6, name: 'kategoria 1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                {
                  id: 7, name: 'kategoria 1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                    {
                      id: 8, name: 'kategoria 1.1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                        { id: 10, name: 'kategoria 1.1.1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                        { id: 11, name: 'kategoria 1.1.1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                      ]
                    },
                    { id: 9, name: 'kategoria 1.1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                  ]
                },
              ]
            },
            { id: 3, name: 'kategoria 1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
          ]
      },
      {
        id: 3, name: 'kategoria 2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories:
          [
            { id: 4, name: 'kategoria 2.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
            { id: 5, name: 'kategoria 2.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
          ]
      }
    ]
    this.isLoaded = true;
  }

  checkIsLogged(): boolean {
    if (!sessionStorage.getItem(environment._shopStorageKey))
      return false;

    let storage =
      JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };

    if (new Date().getTime() > new Date(storage.token.expirationDate).getTime())
      return false;

    return true;
  }

  toggleCategories() {
    this.showCategories = !this.showCategories;
    this.showCategories === true ? this.sidebar.toggle() : this.sidebar.hide();
  }

  onSidebarClose() {
    this.showCategories = false;
  }

  onSidebarInit() {
    this.sidebar.hide();
    this.animateSidebar = true;
  }

  getActualYear(): string {
    return new Date().getFullYear().toString();
  }
}
