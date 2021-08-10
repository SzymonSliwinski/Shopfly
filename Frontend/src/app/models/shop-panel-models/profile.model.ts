import { ProfilesPrivileges } from './profiles-privileges';
import { EmployeesProfiles } from './employees-profiles';

export interface Profile{
    id: number;
    name: string;
    employeesProfiles: EmployeesProfiles[];
    profilesPrivileges: ProfilesPrivileges[];
}