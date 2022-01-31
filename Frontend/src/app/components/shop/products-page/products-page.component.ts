import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Paginator } from 'primeng/paginator';
import { Product } from 'src/app/models/shop-models/product.model';
import { Rating } from 'src/app/models/shop-models/rating.model';
import { ProductsService } from 'src/app/services/shop/product.service';

@Component({
  selector: 'app-products-page',
  templateUrl: './products-page.component.html',
  styleUrls: ['./products-page.component.scss']
})
export class ProductsPageComponent implements OnInit {
  @ViewChild('paginator', { static: true }) paginator!: Paginator
  public productsList: Product[] = [];
  public resultsCount!: number;
  public actualPage!: number;
  public productsUrl: SafeUrl[] = [];
  public actualCategoryFilter?: string;
  public maxPages!: number;
  public isLoaded = false;
  priceMin?: number;
  priceMax?: number;
  sortBy?: number;
  avarageRates: number[] = [];

  constructor(
    private _route: ActivatedRoute,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer,
    private readonly _router: Router
  ) { }

  async ngOnInit(): Promise<void> {
    await this.refresh();
  }

  private refresh() {
    this.actualPage = parseInt(this._route.snapshot.paramMap.get('page')!);
    let filterDto = {} as FilterDto;
    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category']) {
        this.actualCategoryFilter = params['category'];
        filterDto.category = this.actualCategoryFilter;
      }
      if (params['min'] && params['max']) {
        filterDto.min = params['min'];
        this.priceMin = params['min'];
        this.priceMax = params['max'];
        filterDto.max = params['max'];
      }

      if (params['sort']) {
        filterDto.sortBy = params['sort'];
        this.sortBy = params['sort'];
      }

      this.productsList = await this._productService.getByAllRelatedWithCategory(filterDto, this.actualPage.toString());
      this.resultsCount = await this._productService.getCountByCategory(filterDto);
      this.maxPages = this.resultsCount % 30 === 0 ? this.resultsCount / 30 : Math.floor(this.resultsCount / 30) + 1;
      await this.getPhotos();
      this.isLoaded = true;
      return;
    });
  }

  private async getPhotos() {
    this.productsList.forEach(async product => {
      let x = await this.getPhotoForProduct(product.id);
      if (x)
        this.productsUrl[product.id] = x;
      this.getAvgRate(product.ratings!, product.id);

    });
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl | void> {
    const blob = await this._productService.getPhoto(productId);
    if (!blob)
      return;
    const urll = URL.createObjectURL(blob!);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  public onProductClick(productId: number) {
    this._router.navigate([`product/${productId}`]);
  }

  getAvgRate(ratings: Rating[], productId: number) {
    if (ratings.length === 0) {
      this.avarageRates[productId] = 0;
      return;
    }
    let sum = 0;

    ratings.forEach(val => {
      sum += val.rate;
    });
    this.avarageRates[productId] = sum / ratings.length;

  }


  onFilterSearchClick() {
    let query: any = {};

    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category'])
        query['category'] = params['category'];
      if (params['min'])
        query['min'] = params['min'];
      if (params['max'])
        query['max'] = params['max'];
    });

    if (this.priceMin && this.priceMax) {
      query['min'] = this.priceMin;
      query['max'] = this.priceMax;
    }

    if (this.sortBy)
      query['sort'] = this.sortBy;

    this._router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this._router.navigate(
        [`/products/1`],
        { queryParams: query }));
    window.scroll({
      top: 0,
      left: 0,
    });
  }
}


export interface FilterDto {
  category?: string;
  min?: string;
  max?: string;
  sortBy?: number;
}