import { Profile } from './profile.model';
import { Privilege } from './privilege.model';

export interface ProfilesPrivileges{
    profileId: number;
    profile: Profile
    privilageId: number;
    privilege: Privilege;
}