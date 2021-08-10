import { ProductsTags } from './products-tags.model';
import { ProductsVariants } from './products-variants.model';
import { ProductsCarriers } from './products-carriers.model';
import { ProductsPayments } from './products-payments.model';
import { OrdersProducts } from './orders-products.model';
import { CustomerFavouritesProducts } from './customer-favourites-products.model';
import { Rating } from './rating.model';
import { Tax } from './tax.model';
import { Category } from './category.model';
import { Comment } from './comment.model';

export interface Product{
    id: number;
    categoryId: number;
    category: Category;
    name: string;
    taxId: number;
    tax: Tax;
    isLowStock: boolean;
    additionalShippingCost: number
    nettoPrice: number;
    bruttoPrice: number;
    createDate: Date;
    isActive: boolean;
    updateDate: Date;
    description: string;
    comments: Comment[];
    ratings: Rating[];
    clientFavouritesProducts: CustomerFavouritesProducts[];
    ordersProducts: OrdersProducts[];
    productsPayments: ProductsPayments[];
    productsCarriers: ProductsCarriers[];
    productsTags: ProductsTags[];
    productsVariants: ProductsVariants[];
}