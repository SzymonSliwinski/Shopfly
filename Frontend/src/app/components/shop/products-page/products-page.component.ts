import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Params } from '@angular/router';
import { Product } from 'src/app/models/shop-models/product.model';
import { ProductsService } from 'src/app/services/shop/product.service';

@Component({
  selector: 'app-products-page',
  templateUrl: './products-page.component.html',
  styleUrls: ['./products-page.component.scss']
})
export class ProductsPageComponent implements OnInit {
  public productsList: Product[] = [];
  public resultsCount!: number;
  productsUrl: SafeUrl[] = [];
  constructor(
    private _route: ActivatedRoute,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    const page = this._route.snapshot.paramMap.get('page');
    console.log(page);
    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category']) {
        this.productsList = await this._productService.getByAllRelatedWithCategory(params['category'], page!);
        this.resultsCount = await this._productService.getCountByCategory(params['category']);
      }

      this.productsList.forEach(async product => {
        this.productsUrl[product.id] = await this.getPhotoForProduct(product.id);
      });
    });
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }
}
