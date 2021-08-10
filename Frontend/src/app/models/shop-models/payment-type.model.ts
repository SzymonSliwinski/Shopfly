import { ProductsPayments } from './products-payments.model';
import { Order } from './order.model';
export interface PaymentType{
    id: number;
    name: string;
    icon: string;
    orders: Order[];
    productsPayments: ProductsPayments[];
}