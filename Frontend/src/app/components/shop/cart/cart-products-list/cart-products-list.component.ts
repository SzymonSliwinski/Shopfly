import { Component, OnInit } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';

@Component({
  selector: 'app-cart-products-list',
  templateUrl: './cart-products-list.component.html',
  styleUrls: ['./cart-products-list.component.scss']
})
export class CartProductsListComponent implements OnInit {
  public customerCart!: CustomerCart[];
  constructor() { }

  ngOnInit(): void {
    this.customerCart = [
      {
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'produkt 1',
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
      }, {
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'produkt 1',
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
      }, {
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'produkt 1',
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
      }, {
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'produkt 1',
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
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'produkt 2',
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
        productId: 1,
        customerId: 1,
        product: {
          id: 1,
          categoryId: 1,
          name: 'Sed maxime ex. Ut esse ut quia sed Ut esse ut quia sed',
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

  public getTotalBruttoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.bruttoPrice;
    });

    return result;
  }
  getTotalNettoValue(): number {
    var result = 0;
    this.customerCart.forEach(p => {
      result += p.product!.nettoPrice;
    });

    return result;
  }
}
