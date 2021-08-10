import { Product } from './product.model';
export interface Tax{
    id: number;
    name: string;
    interest: number;
    products: Product[];
}