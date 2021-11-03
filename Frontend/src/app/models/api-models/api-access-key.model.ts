import { ApiKeysTablesMethods } from "./api-key-tables-methods.model";

export interface ApiAccessKey {
    id: number;
    createDate: Date;
    key: string;
    apiKeysTablesMethods?: ApiKeysTablesMethods[];
    isActive: boolean;
}