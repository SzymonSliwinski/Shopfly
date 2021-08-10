import { Carrier } from './carrier.model';
import { Product } from './product.model';

export interface ProductsCarriers{
    productId: number;
    product: Product[];
    carrierId: number;
    carrier: Carrier;
}