import { ProductVariant } from './product-variant.model';

export interface ProductColor{
   id: number;
   hexValue: string;
   productVariants: ProductVariant[];
}