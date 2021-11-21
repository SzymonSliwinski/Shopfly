import { HomeProductsList } from "./home-products-lists.model";

export interface HomeList {
    id: number;
    title: string;
    url: string;
    isVisible: boolean;
    homeProductsLists: HomeProductsList[];
}