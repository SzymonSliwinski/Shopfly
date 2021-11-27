import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/shop-models/product.model';

@Component({
  selector: 'app-products-page',
  templateUrl: './products-page.component.html',
  styleUrls: ['./products-page.component.scss']
})
export class ProductsPageComponent implements OnInit {
  public productsList: Product[] = [];
  constructor() { }

  ngOnInit(): void {
    this.productsList = [
      {
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
      }, {
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
      }, {
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
      }, {
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
      }, {
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
      }, {
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
      }, {
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
      }, {
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
      }, {
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
    ]
  }


}
