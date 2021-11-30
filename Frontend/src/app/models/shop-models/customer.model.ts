import { Order } from './order.model';
import { Rating } from './rating.model';
import { CustomerFavouritesProducts } from './customer-favourites-products.model';
export interface Customer {
    id: number;
    name: string;
    surname: string;
    phoneNumber?: string;
    email: string;
    isNewsletterSubscribed: boolean;
    createDate: Date;
    lastLoginDate: Date;
    password?: string;
    comments?: Comment[];
    rating?: Rating[];
    customersFavouritesProducts?: CustomerFavouritesProducts[];
    orders?: Order[];
    isActive: boolean;
}