import { OrderDisplayDto } from './order-display.dto';

export interface OrdersDto {
    newOrdersToday: number;
    activeOrders: number;
    ordersTotalValue: number;
    averageOrderValue: number;
    orderDisplayDto: OrderDisplayDto[];
}