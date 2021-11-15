import { Product } from './product.model';

export interface Category {
    id: number;
    name: string;
    isRoot: boolean;
    parentCategoryId: number | null;
    parentCategory: Category | null;
    childrensCategories: Category[] | null;
    position: number;
    products?: Product[] | null;
}