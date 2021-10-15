import { ProductDiemensions } from './product-diemensions.model';
import { ProductColor } from './product-color.mode';
import { Product } from './product.model';
export interface ProductVariant {
    id: number;
    colorId: number;
    color: ProductColor;
    diemensionsId: number;
    diemension: ProductDiemensions;
    price: number;
    isOnSale: boolean;
    salePercentage: number;
    quantity: number;
    product: Product;
    productId: number
}