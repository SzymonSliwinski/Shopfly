using System.Collections.Generic;
using System.Security.Cryptography;

namespace Common.Models.ShopPanelModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public List<EmployeesProfiles> EmployeesProfiles { get; set; }
    }
}
