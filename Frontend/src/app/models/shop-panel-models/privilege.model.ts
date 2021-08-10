import { ProfilesPrivileges } from './profiles-privileges';
export interface Privilege{
    id: number;
    name: string;
    profilesPrivileges: ProfilesPrivileges[];
}