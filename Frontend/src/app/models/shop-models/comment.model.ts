import { Product } from './product.model';
import { Customer } from './customer.model';
export interface Comment{
    id: number;
    customerId: number;
    customer: Customer;
    productId: number;
    product: Product;
    content: string;
}