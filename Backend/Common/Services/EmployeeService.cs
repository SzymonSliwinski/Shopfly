using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopPanelModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetById(int id)
        {
            var result = await _context.Employees
                .AsQueryable()
                .SingleAsync(e => e.Id == id);

            return result;
        }

        public async Task<Employee> Delete(int id)
        {
            var employeeDb = await GetById(id);
            employeeDb.IsActive = false;
            await _context.SaveChangesAsync();

            return employeeDb;
        }

        public async Task<Employee> Add(Employee employee)
        {
            employee.Name = employee.Name.Trim();
            employee.Surname = employee.Surname.Trim();
            employee.Email = employee.Email.Trim();
            employee.IsActive = true;
            employee.Password = employee.Password.Trim();
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Employee> Update(Employee updatedEmployee)
        {
            var oldEmployee = await GetById(updatedEmployee.Id);
            oldEmployee.Name = updatedEmployee.Name.Trim();
            oldEmployee.Surname = updatedEmployee.Surname.Trim();
            oldEmployee.Email = updatedEmployee.Email.Trim();
            oldEmployee.Password = updatedEmployee.Password.Trim();

            await _context.SaveChangesAsync();
            return oldEmployee;
        }
    }
}
