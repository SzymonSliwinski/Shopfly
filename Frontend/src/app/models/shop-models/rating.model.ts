import { Customer } from './customer.model';
import { Product } from './product.model';
export interface Rating{
    id: number;
    customerId: number;
    customer: Customer;
    productId: number;
    product: Product;
    rate: number;
}