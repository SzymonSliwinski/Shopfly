import { ProductListPhoto } from "./product-list-photo.model";

export interface HomeProductsLists {
    id: number;
    title: string;
    url: string;
    isVisible: boolean;
    photos: ProductListPhoto[];
}