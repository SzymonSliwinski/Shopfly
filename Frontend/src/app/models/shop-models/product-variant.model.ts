import { ProductDiemensions } from './product-diemensions.model';
import { ProductColor } from './product-color.mode';
export interface ProductVariant{
    id: number;
    colorId: number;
    color: ProductColor;
    diemensionsId: number;
    diemension: ProductDiemensions;
    price: number;
    isOnSale: boolean;
    salePercentage: number;
    quantity: number;
}