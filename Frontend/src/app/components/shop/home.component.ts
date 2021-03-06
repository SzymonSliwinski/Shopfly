import { Component, OnInit, Sanitizer, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Category } from 'src/app/models/shop-models/category.model';
import { NavigationEnd, Router } from '@angular/router';
import { HomeProductsList } from 'src/app/models/shop-models/home-products-lists.model';
import { HomeList } from 'src/app/models/shop-models/home-list.model';
import { ListsService } from 'src/app/services/shop/lists.service';
import { CustomerCartService } from 'src/app/services/shop/customer-cart.service';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';
import { CategoryService } from 'src/app/services/shop/category.service';
import { ProductsService } from 'src/app/services/shop/product.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Rating } from 'src/app/models/shop-models/rating.model';
interface Node {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLogged = true;
  showCategories = false;
  isLoaded = false;
  animateSidebar = false;
  isHomeSite = false;
  productsLists: HomeList[] = [];
  allCategories: Category[] = [];
  imagesUrls: SafeUrl[] = [];
  avarageRates: number[] = [];
  treeControl = new FlatTreeControl<Node>(
    node => node.level,
    node => node.expandable,
  );
  hasChild = (_: number, node: Node) => node.expandable;

  private _transformer = (node: Category, level: number) => {
    return {
      expandable: !!node.childrensCategories && node.childrensCategories.length > 0,
      name: node.name,
      level: level,
    };
  };

  private async getPhotos() {
    this.productsLists.forEach(async product => {
      product.homeProductsLists.forEach(async val => {
        this.imagesUrls[val.productId] = await this.getPhotoForProduct(val.productId);
        this.getAvgRate(val.product!.ratings!, val.productId);
      });
    });
  }

  public async getPhotoForProduct(productId: number): Promise<SafeUrl> {
    const blob = await this._productsService.getPhoto(productId);
    const urll = URL.createObjectURL(blob);
    return this._sanitizer.bypassSecurityTrustUrl(urll);
  }

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.childrensCategories,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
  @ViewChild('sidebar') sidebar!: SidebarComponent;

  constructor(
    private readonly _router: Router,
    private readonly _listService: ListsService,
    private readonly _favoritesProductsList: CustomerFavoritesProductsService,
    private readonly _customerCartService: CustomerCartService,
    private readonly _categoryService: CategoryService,
    private readonly _productsService: ProductsService,
    private _sanitizer: DomSanitizer,
  ) {
    this.dataSource.data;
    _router.events.subscribe((val) => {
      if (val instanceof NavigationEnd)
        this.isHomeSite = val.url === '/' ? true : false;
    });
  }

  async ngOnInit(): Promise<void> {
    this.isLogged = this.checkIsLogged();
    this.productsLists = await this._listService.getAll();
    this.allCategories = await this._categoryService.getAll();
    this.dataSource.data = await this._categoryService.getAll();
    this.getPhotos();
    this.isLoaded = true;
  }

  checkIsLogged(): boolean {
    if (!sessionStorage.getItem(environment._shopStorageKey))
      return false;

    let storage =
      JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };

    if (new Date().getTime() > new Date(storage.token.expirationDate).getTime())
      return false;

    return true;
  }

  toggleCategories() {
    this.showCategories = !this.showCategories;
    this.showCategories === true ? this.sidebar.toggle() : this.sidebar.hide();
  }

  onSidebarClose() {
    this.showCategories = false;
  }

  onSidebarInit() {
    this.sidebar.hide();
    this.animateSidebar = true;
  }

  getActualYear(): string {
    return new Date().getFullYear().toString();
  }

  async onAddToFavoritesClick(id: number) {
    await this._favoritesProductsList.add(id);
  }

  async onAddToCartClick(id: number) {
    await this._customerCartService.add(id);
  }

  onCategoryClick(categoryName: string) {
    this._router.navigate(
      ['/products/1'],
      { queryParams: { category: `${categoryName}` } }
    );
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

}
