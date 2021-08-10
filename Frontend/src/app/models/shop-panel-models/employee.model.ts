import { EmployeesProfiles } from './employees-profiles';
export interface Employee{
    id: number;
    name: string;
    surname: string;
    email: string;
    isActive: boolean;
    password: string;
    employeesProfiles: EmployeesProfiles[];

}