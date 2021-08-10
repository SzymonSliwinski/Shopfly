import { ProductVariant } from './product-variant.model';
import { Product } from './product.model';
export interface ProductsVariants{
    productId:number;
    product: Product;
    variantId: number;
    variant: ProductVariant;
}