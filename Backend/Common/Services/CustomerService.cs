using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await _context.Customers
                .AsQueryable()
                .SingleAsync(c => c.Id == id);

            return result;
        }

        public async Task<Customer> Delete(int id)
        {
            var customerDb = await GetById(id);
            customerDb.IsActive = false;
            await _context.SaveChangesAsync();

            return customerDb;
        }

        public async Task<Customer> Add(Customer customer)
        {
            customer.Login = customer.Login.Trim();
            customer.Name = customer.Name.Trim();
            customer.Surname = customer.Surname.Trim();
            customer.PhoneNumber = customer.PhoneNumber.Trim();
            customer.Email = customer.Email.Trim();
            customer.CreateDate = DateTime.Now.ToLocalTime();
            customer.LastLoginDate = DateTime.Now.ToLocalTime();
            customer.Password = customer.Password.Trim();
            customer.IsActive = true;

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Customer> Update(Customer updatedCustomer)
        {
            var oldCustomer = await GetById(updatedCustomer.Id);
            oldCustomer.Name = updatedCustomer.Name.Trim();
            oldCustomer.Surname = updatedCustomer.Surname.Trim();
            oldCustomer.PhoneNumber = updatedCustomer.PhoneNumber.Trim();
            oldCustomer.Email = updatedCustomer.Email.Trim();
            oldCustomer.IsNewsletterSubscribed = updatedCustomer.IsNewsletterSubscribed;
            oldCustomer.LastLoginDate = DateTime.Now.ToLocalTime();

            await _context.SaveChangesAsync();
            return oldCustomer;
        }
    }
}
