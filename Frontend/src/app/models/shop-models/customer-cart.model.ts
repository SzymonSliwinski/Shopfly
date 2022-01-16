import { Customer } from "./customer.model";
import { Product } from "./product.model";

export interface CustomerCart {
    customerId: number;
    customer?: Customer | null;
    productId: number;
    product?: Product | null;
    quantity?: number;
}