import { Order } from './order.model';
import { ProductsCarriers } from './products-carriers.model';

export interface Carrier {
    id: number;
    cost: number;
    name: string;
    logo: string;
    deliveryDaysMinimum: number;
    deliveryDaysMaximum: number;
    productsCarriers?: ProductsCarriers[] | null;
    orders?: Order[] | null;
    isActive: boolean;
}