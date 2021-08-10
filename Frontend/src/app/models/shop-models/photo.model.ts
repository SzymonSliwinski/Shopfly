import { ProductsVariantsPhotos } from './products-variants-photos.model';

export interface Photo{
    id: number;
    isCover: boolean;
    path: string;
    productVariantsPhotos: ProductsVariantsPhotos[];
}