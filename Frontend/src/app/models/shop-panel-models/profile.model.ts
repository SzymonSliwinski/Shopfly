import { EmployeesProfiles } from './employees-profiles';

export interface Profile {
    id: number;
    name: string;
    employeesProfiles?: EmployeesProfiles[];
    hasAccessToOrders: boolean;
    hasAccessToImports: boolean;
    hasAccessToProducts: boolean;
    hasAccessToCustomers: boolean;
    hasAccessToCharts: boolean;
    hasAccessToSettings: boolean;
    hasAccessToApi: boolean;
    hasAccessToEmployees: boolean;
}