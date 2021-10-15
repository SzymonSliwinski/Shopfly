import { ProductVariant } from './product-variant.model';

export interface ProductDiemensions {
   id: number;
   width: number;
   height: number;
   weight: number;
   productVariant: ProductVariant[];
}