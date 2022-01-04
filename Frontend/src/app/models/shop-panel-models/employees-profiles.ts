import { Profile } from './profile.model';
import { Employee } from './employee.model';

export interface EmployeesProfiles {
    employeeId: number;
    employee?: Employee;
    profileId: number;
    profile?: Profile;
}