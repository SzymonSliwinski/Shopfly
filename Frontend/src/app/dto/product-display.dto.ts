import { SafeUrl } from "@angular/platform-browser";

export interface ProductDisplayDto {
    id: number;
    photo: SafeUrl;
    name: string;
    category: string;
    nettoPrice: number;
    bruttoPrice: number;
    isVisible: boolean;
    stock: number;

}