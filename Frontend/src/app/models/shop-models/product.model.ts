import { ProductVariant } from './product-variant.model';
import { ProductsTags } from './products-tags.model';
import { ProductsCarriers } from './products-carriers.model';
import { ProductsPayments } from './products-payments.model';
import { OrdersProducts } from './orders-products.model';
import { CustomerFavouritesProducts } from './customer-favourites-products.model';
import { Rating } from './rating.model';
import { Tax } from './tax.model';
import { Category } from './category.model';
import { Comment } from './comment.model';
import { HomeProductsList } from './home-products-lists.model';

export interface Product {
    id: number;
    categoryId?: number;
    category?: Category;
    name: string;
    taxId?: number;
    tax?: Tax | null;
    isLowStock: boolean;
    additionalShippingCost: number
    nettoPrice: number;
    bruttoPrice: number;
    createDate: Date;
    isActive: boolean;
    isVisible: boolean;
    updateDate: Date;
    description: string;
    comments?: Comment[] | null;
    ratings?: Rating[] | null;
    clientFavouritesProducts?: CustomerFavouritesProducts[] | null;
    ordersProducts?: OrdersProducts[] | null;
    productsPayments?: ProductsPayments[] | null;
    productsCarriers?: ProductsCarriers[] | null;
    productsTags?: ProductsTags[] | null;
    productsVariants?: ProductVariant[] | null;
    homeProductsLists?: HomeProductsList[] | null;
}