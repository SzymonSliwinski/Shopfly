import { Product } from './product.model';
import { Tag } from './tag.model';
export interface ProductsTags{
    tagId: number;
    tag: Tag;
    productId: number;
    product: Product;
}