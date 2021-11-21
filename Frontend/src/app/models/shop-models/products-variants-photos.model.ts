import { Photo } from './photo.model';
import { ProductVariant } from './product-variant.model';

export interface ProductsVariantsPhotos {
    productVariantId: number;
    productVariant?: ProductVariant;
    photoId: number;
    photo?: Photo;
}