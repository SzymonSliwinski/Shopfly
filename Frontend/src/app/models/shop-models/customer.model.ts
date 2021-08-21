import { Order } from './order.model';
import { CustomerFavouritesProducts } from './customers-favourites-products.model';
import { Rating } from './rating.model';

export interface Customer{
    id: number;
    login: string;
    name: string;
    surname: string;
    phoneNumber:string;
    email:string;
    isNewsletterSubscribed: boolean;
    createDate: Date;
    lastLoginDate: Date;
    defaultLanguageId: number; //to do
    password: string;
    comments: Comment[];
    rating: Rating[];
    customersFavouritesProducts: CustomerFavouritesProducts[];
    orders: Order[];
}