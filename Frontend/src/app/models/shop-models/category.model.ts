import { Product } from './product.model';

export interface Category {
    id: number;
    name: string;
    isRoot: boolean;
    parentCategoryId: number;
    parentCategory: Category | null;
    childrensCategories: Category[];
    position: number;
    products?: Product[] | null;
}