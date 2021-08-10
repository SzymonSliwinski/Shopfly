import { ProductsTags } from './products-tags.model';
export interface Tag{
    id: number;
    name: string;
    productsTags: ProductsTags[];
}