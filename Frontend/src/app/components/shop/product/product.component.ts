import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/shop-models/product.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { ProductsService } from 'src/app/services/shop/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  product!: Product;
  isLoaded = false;
  imgUrl!: SafeUrl;
  constructor(
    private readonly _customerCartService: CustomerCartService,
    private readonly _favoritesProductsList: CustomerFavoritesProductsService,
    private readonly _productsService: ProductsService,
    private _route: ActivatedRoute,
    private _sanitizer: DomSanitizer,

  ) { }

  async ngOnInit(): Promise<void> {
    const productId = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.product = await this._productsService.getDetails(productId);
    this.imgUrl = await this.getPhotoForProduct(productId);
    this.isLoaded = true;
  }

  async onAddToFavoritesClick(id: number) {
    await this._favoritesProductsList.add(id);
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productsService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  async onAddToCartClick(id: number) {
    await this._customerCartService.add(id);
  }

}
