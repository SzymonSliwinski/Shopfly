import { Order } from './order.model';
export interface Status{
    id: number;
    name: string;
    orders: Order[];
}