import { Component, OnInit } from '@angular/core';
import { CustomerFavouritesProducts } from 'src/app/models/shop-models/customer-favourites-products.model';
import { CustomerFavoritesProductsService } from 'src/app/services/shop/customer-favorites-products.service';

@Component({
  selector: 'app-favorites-products',
  templateUrl: './favorites-products.component.html',
  styleUrls: ['./favorites-products.component.scss']
})
export class FavoritesProductsComponent implements OnInit {
  public favoritesProducts: CustomerFavouritesProducts[] = [];
  constructor(
    private readonly _customerFavoritesProductsService: CustomerFavoritesProductsService
  ) { }

  async ngOnInit(): Promise<void> {
    this.favoritesProducts = await this._customerFavoritesProductsService.getAllForLoggedUser();
  }
}
