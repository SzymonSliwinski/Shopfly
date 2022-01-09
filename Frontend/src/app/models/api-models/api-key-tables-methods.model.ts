import { ApiAccessKey } from "./api-access-key.model";

export enum TableType {
    employees,
    employeesProfiles,
    profiles,
    customers,
    statuses,
    orders,
    ordersProducts,
    customerFavouritesProducts,
    ratings,
    comments,
    tags,
    productTags,
    products,
    productsPayments,
    paymentTypes,
    carriers,
    productsCarriers,
    taxes,
    categories,
    productsVariants,
    productsVariantsPhotos,
    photos,
    productColors,
    productDiemensions
}

export function TableTypesStringList(): string[] {
    return [
        'employees',
        'employees profiles',
        'profiles',
        'customers',
        'statuses',
        'orders',
        'orders products',
        'customer favourites products',
        'ratings',
        'comments',
        'tags',
        'product tags',
        'products',
        'products payments',
        'payment types',
        'carriers',
        'products carriers',
        'taxes',
        'categories',
        'products variants',
        'products variants photos',
        'photos',
        'product colors',
        'product diemensions'
    ];
}

export function TableTypeToString(type: TableType): string {
    switch (type) {
        case TableType.employees: return 'employees';
        case TableType.employeesProfiles: return 'employeesProfiles';
        case TableType.profiles: return 'profiles';
        case TableType.customers: return 'customers';
        case TableType.statuses: return 'statuses';
        case TableType.orders: return 'orders';
        case TableType.ordersProducts: return 'ordersProducts';
        case TableType.customerFavouritesProducts: return 'customerFavouritesProducts';
        case TableType.ratings: return 'ratings';
        case TableType.comments: return 'comments';
        case TableType.tags: return 'tags';
        case TableType.productTags: return 'productTags';
        case TableType.products: return 'products';
        case TableType.productsPayments: return 'productsPayments';
        case TableType.paymentTypes: return 'paymentTypes';
        case TableType.carriers: return 'carriers';
        case TableType.productsCarriers: return 'productsCarriers';
        case TableType.taxes: return 'taxes';
        case TableType.categories: return 'categories';
        case TableType.productsVariants: return 'productsVariants';
        case TableType.productsVariantsPhotos: return 'productsVariantsPhotos';
        case TableType.photos: return 'photos';
        case TableType.productColors: return 'productColors';
        case TableType.productDiemensions: return 'productDiemensions';
    }
}

export function TableTypeToEnum(type: string): TableType | void {
    switch (type) {
        case 'employees': return TableType.employees;
        case 'employeesProfiles': return TableType.employeesProfiles;
        case 'profiles': return TableType.profiles;
        case 'customers': return TableType.customers;
        case 'statuses': return TableType.statuses;
        case 'orders': return TableType.orders;
        case 'ordersProducts': return TableType.ordersProducts;
        case 'customerFavouritesProducts': return TableType.customerFavouritesProducts;
        case 'ratings': return TableType.ratings;
        case 'comments': return TableType.comments;
        case 'tags': return TableType.tags;
        case 'productTags': return TableType.productTags;
        case 'products': return TableType.products;
        case 'productsPayments': return TableType.productsPayments;
        case 'paymentTypes': return TableType.paymentTypes;
        case 'carriers': return TableType.carriers;
        case 'productsCarriers': return TableType.productsCarriers;
        case 'taxes': return TableType.taxes;
        case 'categories': return TableType.categories;
        case 'productsVariants': return TableType.productsVariants;
        case 'productsVariantsPhotos': return TableType.productsVariantsPhotos;
        case 'photos': return TableType.photos;
        case 'productColors': return TableType.productColors;
        case 'productDiemensions': return TableType.productDiemensions;
    }
}

export enum HttpMethodType {
    post,
    get,
    patch,
    delete
}

export function HttpMethodTypesStringList(): string[] {
    return [
        'post',
        'get',
        'patch',
        'delete'
    ];
}

export function HttpMethodTypeToString(type: HttpMethodType): string {
    switch (type) {
        case HttpMethodType.post: return 'post';
        case HttpMethodType.get: return 'get';
        case HttpMethodType.patch: return 'patch';
        case HttpMethodType.delete: return 'delete';
    }
}

export function HttpMethodTypeToEnum(type: string): HttpMethodType | void {
    switch (type) {
        case 'post': return HttpMethodType.post;
        case 'get': return HttpMethodType.get;
        case 'patch': return HttpMethodType.patch;
        case 'delete': return HttpMethodType.delete;
    }
}

export interface ApiKeysTablesMethods {
    id: number;
    apiAccessKey?: ApiAccessKey;
    apiAccessKeyId: number;
    table: TableType;
    httpMethod: HttpMethodType;
}
