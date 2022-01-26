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
  constructor(
    private _route: ActivatedRoute,
    private readonly _productService: ProductsService,
    private _sanitizer: DomSanitizer,
    private readonly _router: Router
  ) { }

  async ngOnInit(): Promise<void> {
    // this.paginator.changePageToFirst(null);
    await this.refresh();
    //  this.updateCurrentPage(this.actualPage);

  }

  private refresh() {
    this.actualPage = parseInt(this._route.snapshot.paramMap.get('page')!);
    // this.updateCurrentPage(this.actualPage);
    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category']) {
        this.actualCategoryFilter = params['category'];
        this.productsList = await this._productService.getByAllRelatedWithCategory(params['category'], this.actualPage.toString());
        this.resultsCount = await this._productService.getCountByCategory(params['category']);
      }

      this.productsList.forEach(async product => {
        this.productsUrl[product.id] = await this.getPhotoForProduct(product.id);
      });
    });
  }

  paginate(event: any) {
    if (this.actualCategoryFilter) {
      console.log(event)
      this._router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
        this._router.navigate(
          [`/products/${parseInt(event.page + 1)}`],
          { queryParams: { category: `${this.actualCategoryFilter}` } }));
      // this._router.navigate(
      //   [`/products/${parseInt(event.page + 1)}`],
      //   { queryParams: { category: `${this.actualCategoryFilter}` } }
      // );
      // this.refresh();
    }
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  // private updateCurrentPage(currentPage: number): void {
  //   setTimeout(() => this.paginator.changePage(currentPage));
  // }
}
