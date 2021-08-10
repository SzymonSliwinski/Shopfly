import { Product } from './product.model';
import { Customer } from './customer.model';

export interface CustomerFavouritesProducts{
    customerId: number;
    customer: Customer;
    productId: number;
    product: Product;
}