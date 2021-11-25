import { Component, OnInit } from '@angular/core';
import { CustomerFavouritesProducts } from 'src/app/models/shop-models/customer-favourites-products.model';

@Component({
  selector: 'app-favorites-products',
  templateUrl: './favorites-products.component.html',
  styleUrls: ['./favorites-products.component.scss']
})
export class FavoritesProductsComponent implements OnInit {
  public favoritesProducts: CustomerFavouritesProducts[] = [];
  constructor() { }

  ngOnInit(): void {
    this.favoritesProducts = [
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
