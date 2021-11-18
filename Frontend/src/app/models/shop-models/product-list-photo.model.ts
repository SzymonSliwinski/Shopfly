import { HomeProductsLists } from "./home-products-lists.model";

export interface ProductListPhoto {
    id: number;
    listId: number;
    list: HomeProductsLists;
    photo: string;
}