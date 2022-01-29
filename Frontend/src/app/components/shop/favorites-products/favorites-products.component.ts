import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CustomerFavouritesProducts } from 'src/app/models/shop-models/customer-favourites-products.model';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { ProductsService } from 'src/app/services/shop/product.service';

@Component({
  selector: 'app-favorites-products',
  templateUrl: './favorites-products.component.html',
  styleUrls: ['./favorites-products.component.scss']
})
export class FavoritesProductsComponent implements OnInit {
  public favoritesProducts: CustomerFavouritesProducts[] = [];
  public productsUrl: SafeUrl[] = [];
  isLoaded = false;

  constructor(
    private readonly _customerFavoritesProductsService: CustomerFavoritesProductsService,
    private readonly _productService: ProductsService,
    private readonly _router: Router,
    private _sanitizer: DomSanitizer,
  ) { }

  async ngOnInit(): Promise<void> {
    this.favoritesProducts = await this._customerFavoritesProductsService.getAllForLoggedUser();
    this.favoritesProducts.forEach(async val => {
      this.productsUrl[val.productId] = await this.getPhotoForProduct(val.productId!);
    });
    this.isLoaded = true;
  }

  public onProductClick(productId: number) {
    this._router.navigate([`product/${productId}`]);
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }
}
