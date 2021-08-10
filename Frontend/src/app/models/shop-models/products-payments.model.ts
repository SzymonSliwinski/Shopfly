import { PaymentType } from './payment-type.model';
import { Product } from './product.model';
export interface ProductsPayments{
    productId: number;
    product: Product;
    paymentTypeId: number;
    paymentType: PaymentType;
}