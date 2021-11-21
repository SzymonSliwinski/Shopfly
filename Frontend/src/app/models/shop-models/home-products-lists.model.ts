import { HomeList } from "./home-list.model";
import { Product } from "./product.model";

export interface HomeProductsList {
    productId: number;
    listId: number;
    homeList: HomeList;
    product: Product;
}