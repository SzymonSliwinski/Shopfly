import { Product } from './product.model';
import { Order } from './order.model';
export interface OrdersProducts{
    orderId: number;
    order: Order;
    productId: number;
    product: Product;
    productQuantity: number;
}