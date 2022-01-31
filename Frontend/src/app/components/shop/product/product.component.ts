import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/shop-models/product.model';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { ProductsService } from 'src/app/services/shop/product.service';
import { environment } from 'src/environments/environment';
import { Rating } from 'src/app/models/shop-models/rating.model';
import { RatingService } from 'src/app/services/shop/rating.service';
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  product!: Product;
  isLoaded = false;
  imgUrl!: SafeUrl;
  isLogged = false;
  userRating: Rating = {} as Rating;
  avgRate: number = 0;
  constructor(
    private readonly _customerCartService: CustomerCartService,
    private readonly _favoritesProductsList: CustomerFavoritesProductsService,
    private readonly _productsService: ProductsService,
    private _route: ActivatedRoute,
    private _sanitizer: DomSanitizer,
    private readonly _ratingService: RatingService
  ) { }

  async ngOnInit(): Promise<void> {
    if (sessionStorage.getItem(environment._shopStorageKey) && JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token)
      this.isLogged = true;
    const productId = parseInt(this._route.snapshot.paramMap.get('id')!);
    this.product = await this._productsService.getDetails(productId);
    this.imgUrl = await this.getPhotoForProduct(productId);
    this.isLoaded = true;
    this.setAvgRate();
    this.setUserRating();
  }

  setUserRating() {
    const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
    if (!this.product.ratings?.find(c => c.customerId === userId))
      return;
    this.userRating = this.product.ratings!.find(c => c.customerId === userId)!;
  }

  setAvgRate() {
    if (this.product.ratings?.length === 0)
      return;

    let sum = 0;
    this.product.ratings!.forEach(val => {
      sum += val.rate;
    });
    this.avgRate = sum / this.product.ratings!.length;
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

  async onUserRate(rate: number) {
    const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
    this.userRating.rate = rate;
    this.userRating.customerId = userId;
    this.userRating.productId = this.product.id;
    await this._ratingService.add(this.userRating);
    this.setAvgRate();
  }

}
