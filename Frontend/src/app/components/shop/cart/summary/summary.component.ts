import { Component, OnInit } from '@angular/core';
import { CustomerCart } from 'src/app/models/shop-models/customer-cart.model';
import { Order } from 'src/app/models/shop-models/order.model';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent implements OnInit {
  public order!: Order;
  public products!: CustomerCart[];
  constructor() { }

  ngOnInit(): void {
    this.order = {
      id: 1,
      paymentTypeId: 1,
      statusId: 1,
      carrierId: 1,
      date: new Date(),
      deliveryAddressCity: 'Gdańsk',
      deliveryAddressCountry: 'Polska',
      deliveryAddressPostal: '80-518',
      deliveryAddressStreet: 'Grunwaldzka 21A',
      isActive: true,
      totalPrice: 1234.56,
      customerId: 1,
      additionalDescription: '123456',
      completeDate: new Date()
    };

    this.products = [
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
    ];


  }
}
