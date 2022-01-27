import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Paginator } from 'primeng/paginator';
import { Product } from 'src/app/models/shop-models/product.model';
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
    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category']) {
        this.actualCategoryFilter = params['category'];
        this.productsList = await this._productService.getByAllRelatedWithCategory(params['category'], this.actualPage.toString());
        this.resultsCount = await this._productService.getCountByCategory(params['category']);
        this.maxPages = this.resultsCount % 30 === 0 ? this.resultsCount / 30 : Math.floor(this.resultsCount / 30) + 1;
        await this.getPhotos();
        this.isLoaded = true;
        return;
      }
    });
  }

  private async getPhotos() {
    this.productsList.forEach(async product => {
      this.productsUrl[product.id] = await this.getPhotoForProduct(product.id);
    });
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }
}
