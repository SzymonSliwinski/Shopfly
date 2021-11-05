using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class ProfilesPrivilegesService
    {
        private readonly AppDbContext _context;
        public ProfilesPrivilegesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProfilesPrivileges> FindOne(int profileId, int privilegeId)
        {
            var result = await _context.ProfilesPrivileges
                .AsQueryable()
                .SingleAsync(pp => pp.ProfileId == profileId && pp.PrivilegeId == privilegeId);

            return result;
        }

        public async Task<ProfilesPrivileges> Delete(int profileId, int privilegeId)
        {
            var profilesPrivilegesDb = await FindOne(profileId, privilegeId);
            _context.Remove(profilesPrivilegesDb);
            await _context.SaveChangesAsync();

            return profilesPrivilegesDb;
        }

        public async Task<ProfilesPrivileges> Add(ProfilesPrivileges profilesPrivileges)
        {
            var newProfilesPrivileges = new ProfilesPrivileges()
            {
                ProfileId = profilesPrivileges.ProfileId,
                PrivilegeId = profilesPrivileges.PrivilegeId
            };

            await _context.AddAsync(newProfilesPrivileges);
            await _context.SaveChangesAsync();

            return newProfilesPrivileges;
        }

        public async Task<ProfilesPrivileges> Update(ProfilesPrivileges oldProfilesPrivileges, ProfilesPrivileges newProfilesPrivileges)
        {
            await Delete(oldProfilesPrivileges.ProfileId, oldProfilesPrivileges.PrivilegeId);
            await Add(newProfilesPrivileges);
            return newProfilesPrivileges;
        }

        public async Task<List<ProfilesPrivileges>> AddMany(List<ProfilesPrivileges> profilesPrivilegesList)
        {
            foreach (var profilesPrivileges in profilesPrivilegesList)
                await Add(profilesPrivileges);

            return profilesPrivilegesList;
        }

        public async Task<List<ProfilesPrivileges>> RemoveMany(List<ProfilesPrivileges> profilesPrivilegesList)
        {
            foreach (var profilesPrivileges in profilesPrivilegesList)
                await Delete(profilesPrivileges.ProfileId, profilesPrivileges.PrivilegeId);

            return profilesPrivilegesList;
        }
    }
}
