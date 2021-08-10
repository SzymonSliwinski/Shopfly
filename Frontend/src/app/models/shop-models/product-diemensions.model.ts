import { ProductsVariants } from './products-variants.model';
export interface ProductDiemensions{
   id: number;
   width: number;
   height: number;
   weight: number; 
   productVariant: ProductsVariants[];
}