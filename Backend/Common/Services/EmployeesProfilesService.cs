using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class EmployeesProfilesService
    {
        private readonly AppDbContext _context;
        public EmployeesProfilesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeesProfiles> FindOne(int employeeId, int profileId)
        {
            var result = await _context.EmployeesProfiles
                .AsQueryable()
                .SingleAsync(ep => ep.EmployeeId == employeeId && ep.ProfileId == profileId);

            return result;
        }

        public async Task<EmployeesProfiles> Delete(int employeeId, int profileId)
        {
            var employeesProfilesDb = await FindOne(employeeId, profileId);
            _context.Remove(employeesProfilesDb);
            await _context.SaveChangesAsync();

            return employeesProfilesDb;
        }

        public async Task<EmployeesProfiles> Add(EmployeesProfiles employeesProfiles)
        {
            var newEmployeesProfiles = new EmployeesProfiles()
            {
                EmployeeId = employeesProfiles.EmployeeId,
                ProfileId = employeesProfiles.ProfileId
            };

            await _context.AddAsync(newEmployeesProfiles);
            await _context.SaveChangesAsync();

            return newEmployeesProfiles;
        }

        public async Task<EmployeesProfiles> Update(UpdateModelDto<EmployeesProfiles> modelsDto)
        {
            await Delete(modelsDto.OldModel.EmployeeId, modelsDto.OldModel.ProfileId);
            await Add(modelsDto.NewModel);
            return modelsDto.NewModel;
        }

        public async Task<List<EmployeesProfiles>> AddMany(List<EmployeesProfiles> employeesProfilesList)
        {
            foreach (var employeesProfiles in employeesProfilesList)
                await Add(employeesProfiles);

            return employeesProfilesList;
        }

        public async Task<List<EmployeesProfiles>> RemoveMany(List<EmployeesProfiles> employeesProfilesList)
        {
            foreach (var employeesProfiles in employeesProfilesList)
                await Delete(employeesProfiles.EmployeeId, employeesProfiles.ProfileId);

            return employeesProfilesList;
        }
    }
}
