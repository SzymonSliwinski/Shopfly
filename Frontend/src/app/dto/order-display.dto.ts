export interface OrderDisplayDto {
    id: number;
    customerName: string;
    totalValue: number;
    paymentType: string;
    status: string;
    date: Date;
}